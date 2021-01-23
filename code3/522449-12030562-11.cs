    string itemDescription = itemElement.GetElementsByTagName("description")[0].InnerText;
    if (words.Any(
        wordOrPhrase =>
        Regex.IsMatch(itemDescription,
                      @"\b" + Regex.Escape(wordOrPhrase) + @"\b",
                      RegexOptions.IgnoreCase)))
    {
        ...
    }
