        private static void ConvertLanguage(TextReader input, TextWriter output, SupportedLanguage language, Action<string> onError)
        {
            using (IParser parser = ParserFactory.CreateParser(language, input))
            {
                parser.Parse();
                var specials = parser.Lexer.SpecialTracker.RetrieveSpecials();
                var result = parser.CompilationUnit;
                //if (parser.Errors.Count > 0)
                //    MessageBox.Show(parser.Errors.ErrorOutput, "Parse errors");
                IOutputAstVisitor outputVisitor;
                if (language == SupportedLanguage.CSharp)
                    outputVisitor = new VBNetOutputVisitor();
                else
                    outputVisitor = new CSharpOutputVisitor();
                outputVisitor.Options.IndentationChar = ' ';
                outputVisitor.Options.IndentSize = 4;
                outputVisitor.Options.TabSize = 4;
                
                using (SpecialNodesInserter.Install(specials, outputVisitor))
                    result.AcceptVisitor(outputVisitor, null);
                if (outputVisitor.Errors.Count > 0 && onError != null)
                    onError(outputVisitor.Errors.ErrorOutput);
                output.Write(outputVisitor.Text);
            }
        }
