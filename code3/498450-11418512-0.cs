    private string myReplace(string text)
        {
            if (!text.Contains(' '))
            {
                return text.ToLower().Equals("let's") ? text : text.Replace("'s", string.Empty);
            }
            else
            {
                int index = text.IndexOf(' ');
                return myReplace(text.Substring(0, index)) + " " + myReplace(text.Substring(index + 1));
            }
        }
