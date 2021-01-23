    public class ParseException : Exception { }
    
    public static class ExprValidator
    {
        public static bool Validate(string str)
        {
            try
            {
                string term = Term(str);
                string stripTrailing = Whitespace(term);
                
                return stripTrailing.Length == 0;
            }
            catch(ParseException) { return false; }
        }
    
        static string Term(string str)
        {
            if(str == string.Empty) return str;
            char current = str[0];
            
            if(current == '(')
            {
                string term = LBracket(str);
                string rBracket = Term(term);
                string temp = Whitespace(rBracket);
                return RBracket(temp);
            }
            else if(Char.IsDigit(current))
            {
                string rest = Digit(str);
                try
                {
                    //possibly match op term
                    string op = Op(rest);
                    return Term(op);
                }
                catch(ParseException) { return rest; }
            }
            else if(Char.IsWhiteSpace(current))
            {
                string temp = Whitespace(str);
                return Term(temp);
            }
            else throw new ParseException();
        }
    
        static string Op(string str)
        {
            string t1 = Whitespace_(str);
            string op = MatchOp(t1);
            return Whitespace_(op);
        }
    
        static string MatchOp(string str)
        {
            if(str.StartsWith("AND")) return str.Substring(3);
            else if(str.StartsWith("OR")) return str.Substring(2);
            else throw new ParseException();
        }
    
        static string LBracket(string str)
        {
            return MatchChar('(')(str);
        }
    
        static string RBracket(string str)
        {
            return MatchChar(')')(str);
        }
    
        static string Digit(string str)
        {
            return MatchChar(Char.IsDigit)(str);
        }
    
        static string Whitespace(string str)
        {
            if(str == string.Empty) return str;
            
            int i = 0;
            while(i < str.Length && Char.IsWhiteSpace(str[i])) { i++; }
            
            return str.Substring(i);
        }
        
        //match at least one whitespace character
        static string Whitespace_(string str)
        {
            string stripFirst = MatchChar(Char.IsWhiteSpace)(str);
            return Whitespace(stripFirst);
        }
    
        static Func<string, string> MatchChar(char c)
        {
            return MatchChar(chr => chr == c);
        }
    
        static Func<string, string> MatchChar(Func<char, bool> pred)
        {
            return input => {
                if(input == string.Empty) throw new ParseException();
                else if(pred(input[0])) return input.Substring(1);
                else throw new ParseException();
            };
        }
    }
