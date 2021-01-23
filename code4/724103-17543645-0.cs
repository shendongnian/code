    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    static class Program
    {
        static void Main()
        {
            // and will produce each token is separated with a white space like : ( x + 3 > 5 * y ) && ( z >= 3 || k != x )
            string recombined = string.Join(" ", Tokenize("(x+3>5*y)&&(z>=3 || k!=x)"));
            // output: ( x + 3 > 5 * y ) && ( z >= 3 || k != x )
        }
        public static IEnumerable<string> Tokenize(string input)
        {
            var buffer = new StringBuilder();
            foreach (char c in input)
            {
                if (char.IsWhiteSpace(c))
                {
                    if (buffer.Length > 0)
                    {
                        yield return Flush(buffer);
                    }
                    continue; // just skip whitespace
                }
    
                if (IsOperatorChar(c))
                {
                    if (buffer.Length > 0)
                    {
                        // we have back-buffer; could be a>b, but could be >=
                        // need to check if there is a combined operator candidate
                        if (!CanCombine(buffer, c))
                        {
                            yield return Flush(buffer);
                        }
                    }
                    buffer.Append(c);
                    continue;
                }
    
                // so here, the new character is *not* an operator; if we have
                // a back-buffer that *is* operators, yield that
                if (buffer.Length > 0 && IsOperatorChar(buffer[0]))
                {
                    yield return Flush(buffer);
                }
    
                // append
                buffer.Append(c);
            }
            // out of chars... anything left?
            if (buffer.Length != 0)
                yield return Flush(buffer);
        }
        static string Flush(StringBuilder buffer)
        {
            string s = buffer.ToString();
            buffer.Clear();
            return s;
        }
        static readonly string[] operators = { "+", "-", "*", "/", "%", "=", "&&", "||", "==", ">=", ">", "<", "<=", "!=", "(",")" };
        static readonly char[] opChars = operators.SelectMany(x => x.ToCharArray()).Distinct().ToArray();
    
        static bool IsOperatorChar(char newChar)
        {
            return Array.IndexOf(opChars, newChar) >= 0;
        }
        static bool CanCombine(StringBuilder buffer, char c)
        {
            foreach (var op in operators)
            {
                if (op.Length <= buffer.Length) continue;
                // check starts with same plus this one
                bool startsWith = true;
                for (int i = 0; i < buffer.Length; i++)
                {
                    if (op[i] != buffer[i])
                    {
                        startsWith = false;
                        break;
                    }
                }
                if (startsWith && op[buffer.Length] == c) return true;
            }
            return false;
        }
    
    }
