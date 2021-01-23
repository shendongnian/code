    public class CustomTokenParser
    {
        public char OpenToken { get; set; }
        public char CloseToken { get; set; }
        public bool ThrowOnError { get; set; }
        public CustomTokenParser()
        {
            OpenToken = '{';
            CloseToken = '}';
            ThrowOnError = true;
        }
        public CustomTokenParser(char openToken, char closeToken, bool throwOnError)
        {
            this.OpenToken = openToken;
            this.CloseToken = closeToken;
            this.ThrowOnError = throwOnError;
        }        
        public string[] Parse(string input)
        {
            bool open = false;
            int openIndex = -1;
            List<string> matches = new List<string>();
            for (int i = 0; i < input.Length; i++)
            {
                if (!open && input[i] == OpenToken)
                {
                    open = true;
                    openIndex = i;
                }
                else if (open && input[i] == CloseToken)
                {
                    open = false;
                    string match = input.Substring(openIndex + 1, i - openIndex - 1);
                    matches.Add(match);
                }
                else if (open && input[i] == OpenToken && ThrowOnError)
                    throw new Exception("Open token found while match is open");
                else if (!open && input[i] == CloseToken && ThrowOnError)
                    throw new Exception("Close token found while match is not open");
            }
            return matches.ToArray();
        }
    }
