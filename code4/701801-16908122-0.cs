    internal class UserName : IParseRule
    {
        public bool Parse(string input, out string errorMessage)
        {
            // TODO: Do your checks here
            if (string.IsNullOrWhiteSpace(input))
            {
                errorMessage = "User name cannot be empty or consist of white space only.";
                return false;
            }
            else
            {
                errorMessage = null;
                return true;
            }
        }
    }
