        private string ValidChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ123456789'-";
        private IEnumerable<string> SplitRemoveInvalid(string input)
        {
            string tmp = "";
            foreach(char c in input)
            {
                if(c == '\n')
                {
                    if(!String.IsNullOrEmpty(tmp))
                    {
                        yield return tmp;
                        tmp = "";
                    }
                    continue;
                }
                if(ValidChars.Contains(c))
                {
                    tmp += tmp;
                }
            }
            if (!String.IsNullOrEmpty(tmp)) yield return tmp;
        }
