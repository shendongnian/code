    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;
    namespace Example.SqlPreprocessor
    {
        class Parser
        {
            enum Symbol
            {
                None,
                LPar,
                RPar,
                Equals,
                Text,
                NumberIf,
                If,
                NumberElse,
                NumberEnd,
                Identifier
            }
            List<string> _input; // Raw SQL with preprocessor directives.
            int _currentLineIndex = 0;
            // Simulates variables used in conditions
            Dictionary<string, string> _variableValues = new Dictionary<string, string> { 
                { "VariableA", "Case1" },
                { "VariableB", "CaseX" }
            };
            Symbol _sy; // Current symbol.
            string _string; // Identifier or text line;
            Queue<string> _textQueue = new Queue<string>(); // Buffered text parts of a single line.
            int _lineNo; // Current line number for error messages.
            string _line; // Current line for error messages.
            /// <summary>
            /// Get the next line from the input.
            /// </summary>
            /// <returns>Input line or null if no more lines are available.</returns>
            string GetLine()
            {
                if (_currentLineIndex >= _input.Count) {
                    return null;
                }
                _line = _input[_currentLineIndex++];
                _lineNo = _currentLineIndex;
                return _line;
            }
            /// <summary>
            /// Get the next symbol from the input stream and stores it in _sy.
            /// </summary>
            void GetSy()
            {
                string s;
                if (_textQueue.Count > 0) { // Buffered text parts available, use one from these.
                    s = _textQueue.Dequeue();
                    switch (s.ToLower()) {
                        case "(":
                            _sy = Symbol.LPar;
                            break;
                        case ")":
                            _sy = Symbol.RPar;
                            break;
                        case "=":
                            _sy = Symbol.Equals;
                            break;
                        case "if":
                            _sy = Symbol.If;
                            break;
                        default:
                            _sy = Symbol.Identifier;
                            _string = s;
                            break;
                    }
                    return;
                }
                // Get next line from input.
                s = GetLine();
                if (s == null) {
                    _sy = Symbol.None;
                    return;
                }
                s = s.Trim(' ', '\t');
                if (s[0] == '#') { // We have a preprocessor directive.
                    // Split the line in order to be able get its symbols.
                    string[] parts = Regex.Split(s, @"\b|[^#_a-zA-Z0-9()=]");
                    // parts[0] = #
                    // parts[1] = if, else, end
                    switch (parts[1].ToLower()) {
                        case "if":
                            _sy = Symbol.NumberIf;
                            break;
                        case "else":
                            _sy = Symbol.NumberElse;
                            break;
                        case "end":
                            _sy = Symbol.NumberEnd;
                            break;
                        default:
                            Error("Invalid symbol #{0}", parts[0]);
                            break;
                    }
                    // Store the remaining parts for later.
                    for (int i = 2; i < parts.Length; i++) {
                        string part = parts[i].Trim(' ', '\t');
                        if (part != "") {
                            _textQueue.Enqueue(part);
                        }
                    }
                } else { // We have an ordinary SQL text line.
                    _sy = Symbol.Text;
                    _string = s;
                }
            }
            void Error(string message, params  object[] args)
            {
                // Make sure parsing stops here
                _sy = Symbol.None;
                _textQueue.Clear();
                _input.Clear();
                message = String.Format(message, args) +
                          String.Format(" in line {0}\r\n\r\n{1}", _lineNo, _line);
                Output("------");
                Output(message);
                MessageBox.Show(message, "Error");
            }
            /// <summary>
            /// Writes the processed line to a (simulated) output stream.
            /// </summary>
            /// <param name="line">Line to be written to output</param>
            void Output(string line)
            {
                Console.WriteLine(line);
            }
            /// <summary>
            /// Starts the parsing process.
            /// </summary>
            public void Parse()
            {
                // Simulate an input stream.
                _input = new List<string> {
                    "select column1",
                    "from",
                    "#if(VariableA = Case1)",
                    "	 #if(VariableB = Case3)",
                    "		 table3",
                    "	 #else",
                    "		 table4",
                    "	 #end",
                    "#else if(VariableA = Case2)",
                    "    table2",
                    "#else",
                    "	 defaultTable",
                    "#end"
                };
                // Clear previous parsing
                _textQueue.Clear();
                _currentLineIndex = 0;
                // Get first symbol and start parsing
                GetSy();
                if (LineSequence(true)) {
                    // TODO: OK do something with the processed sql
                } else {
                    Output("*** ABORTED ***");
                }
            }
            // The following methods parse according the the EBNF syntax.
            bool LineSequence(bool writeOutput)
            {   
                // EBNF:  LineSequence = { TextLine | IfStatement }.
                while (_sy == Symbol.Text || _sy == Symbol.NumberIf) {
                    if (_sy == Symbol.Text) {
                        if (!TextLine(writeOutput)) {
                            return false;
                        }
                    } else if (_sy == Symbol.NumberIf) {
                        if (!IfStatement(writeOutput)) {
                            return false;
                        }
                    }
                }
                return true;
            }
            bool TextLine(bool writeOutput)
            {
                // EBNF:  TextLine = <string>.
                if (writeOutput) {
                    Output(_string);
                }
                GetSy();
                return true;
            }
            bool IfStatement(bool writeOutput)
            {
                // EBNF:  IfStatement = IfLine LineSequence { ElseIfLine LineSequence } [ ElseLine LineSequence ] EndLine.
                bool result;
                if (IfLine(out result) && LineSequence(writeOutput && result)) {
                    writeOutput &= !result; // Only one section can produce an output.
                    while (_sy == Symbol.NumberElse) {
                        GetSy();
                        if (_sy == Symbol.If) { // We have an #else if
                            if (!ElseIfLine(out result)) {
                                return false;
                            }
                            if (!LineSequence(writeOutput && result)) {
                                return false;
                            }
                            writeOutput &= !result; // Only one section can produce an output.
                        } else { // We have a simple #else
                            if (!LineSequence(writeOutput)) {
                                return false;
                            }
                            break; // We can have only one #else statement.
                        }
                    }
                    if (_sy != Symbol.NumberEnd) {
                        Error("'#end' expected");
                        return false;
                    }
                    GetSy();
                    return true;
                }
                return false;
            }
            bool IfLine(out bool result)
            {
                // EBNF:  IfLine = "#if" "(" Condition ")".
                result = false;
                GetSy();
                if (_sy != Symbol.LPar) {
                    Error("'(' expected");
                    return false;
                }
                GetSy();
                if (!Condition(out result)) {
                    return false;
                }
                if (_sy != Symbol.RPar) {
                    Error("')' expected");
                    return false;
                }
                GetSy();
                return true;
            }
            private bool Condition(out bool result)
            {
                // EBNF:  Condition = Identifier "=" Identifier.
                string variable;
                string expectedValue;
                string variableValue;
                result = false;
                // Identifier "=" Identifier
                if (_sy != Symbol.Identifier) {
                    Error("Identifier expected");
                    return false;
                }
                variable = _string; // The first identifier is a variable.
                GetSy();
                if (_sy != Symbol.Equals) {
                    Error("'=' expected");
                    return false;
                }
                GetSy();
                if (_sy != Symbol.Identifier) {
                    Error("Value expected");
                    return false;
                }
                expectedValue = _string;  // The second identifier is a value.
                // Search the variable
                if (_variableValues.TryGetValue(variable, out variableValue)) {
                    result = variableValue == expectedValue; // Perform the comparison.
                } else {
                    Error("Variable '{0}' not found", variable);
                    return false;
                }
                GetSy();
                return true;
            }
            bool ElseIfLine(out bool result)
            {
                // EBNF:  ElseIfLine = "#else" "if" "(" Condition ")".
                result = false;
                GetSy(); // "#else" already processed here, we are only called if the symbol is "if"
                if (_sy != Symbol.LPar) {
                    Error("'(' expected");
                    return false;
                }
                GetSy();
                if (!Condition(out result)) {
                    return false;
                }
                if (_sy != Symbol.RPar) {
                    Error("')' expected");
                    return false;
                }
                GetSy();
                return true;
            }
        }
    }
