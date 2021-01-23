    static List<string> GetParts(string text, string token, bool inclToken)
    {
        List<string> items = new List<string>();
        int index = text.IndexOf(token, StringComparison.OrdinalIgnoreCase);
        while (index > -1)
        {
            index += token.Length;
            int endIndex = text.IndexOf(token, index, StringComparison.OrdinalIgnoreCase);
            if (endIndex == -1)
            {
                string item = String.Format("{0}{1}", inclToken ? token : "", text.Substring(index));
                items.Add(item);
                break;
            }
            else
            {
                string item = String.Format("{0}{1}{0}", inclToken ? token : "", text.Substring(index, endIndex-index));
                items.Add(item);
            }
            index = text.IndexOf(token, endIndex, StringComparison.OrdinalIgnoreCase);
        }
        return items;
    }
