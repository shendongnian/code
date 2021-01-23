    public static class ValidParenthesisExt
    {
        private static readonly Map<char, char>
            _parenthesis = new Map<char, char>
            {
                {'(', ')'},
                {'{', '}'},
                {'[', ']'}
            };
        public static bool IsValidParenthesis(this string input)
        {
            var stack = new Stack<char>();
            foreach (var c in input)
            {
                if (_parenthesis.Forward.Contains(c))
                    stack.Push(c);
                else
                {
                    if (stack.Count == 0) return false;
                    if (_parenthesis.Reverse[c] != stack.Pop())
                        return false;
                }
            }
            return stack.Count == 0;
        }
    }
