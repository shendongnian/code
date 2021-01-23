    private static IEnumerable<String> GetListFromDelimitedText(String text)
    {
      var textSplit = text.Split(new[] { "~~~~~~~~" }, StringSplitOptions.None);
      var header = GetHeaderOfRtf(textSplit);
      var footer = GetFooterOfRtf(textSplit);
      var listWithoutHeaderAndFooter =
        textSplit.Where((text, index) => index > 0 && index < textSplit.Length - 1);
      return GetSnippetsWithHeaderAndFooter(listWithoutHeaderAndFooter, header, footer);
    }
    private static IEnumerable<String> GetSnippetsWithHeaderAndFooter(IEnumerable<String> snippetList, String header, String footer)
    {
      return snippetList.Select(text =>
        {
          var textWithoutLeadingBracket = text.Substring(text.IndexOf('}') + 1);
          var cleanedText = textWithoutLeadingBracket.Substring(0, textWithoutLeadingBracket.LastIndexOf('{'));
          return header + cleanedText + footer;
        }
      );
    }
    private static string GetFooterOfRtf(IEnumerable<String> textSplit)
    {
      var lastSplit = textSplit.Last();
      return lastSplit.Substring(lastSplit.IndexOf('}') + 1);
    }
    private static string GetHeaderOfRtf(IEnumerable<String> textSplit)
    {
      var firstSplit = textSplit.First();
      return firstSplit.Substring(0, firstSplit.LastIndexOf('{'));
    }
