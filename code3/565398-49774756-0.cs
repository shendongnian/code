    string GetNumberFromEnd(string text)
    {
        int i = text.Length - 1;
        while (i >= 0)
        {
            if (!char.IsNumber(text[i])) break;
            i--;
        }
        return text.Substring(i + 1);
    }
