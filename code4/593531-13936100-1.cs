    HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
    doc.LoadHtml(html);  // this is your string
    string wordToFind = "TSX Symbol Changes -";
    var fontTSX = doc.DocumentNode.Elements("font")
        .FirstOrDefault(f => f.InnerText.Contains(wordToFind));
    if (fontTSX != null)
    {
        string innerText = fontTSX.InnerText.Trim();
        innerText = innerText.Substring(innerText.IndexOf(wordToFind) + wordToFind.Length);
        String[] words = innerText.Split();
        String monthName = words.First();
        var monthInfo = CultureInfo.InvariantCulture.DateTimeFormat.MonthNames
            .Select((mn, i) => new{ MonthName = mn, Value = i+1 })
            .FirstOrDefault(x => x.MonthName.Equals(monthName, StringComparison.OrdinalIgnoreCase));
        if (monthInfo != null)
        {
            int month = monthInfo.Value;
            int day = int.MinValue;
            // now extract your range
            IEnumerable<int> days = words
                .Where(w => w.Length >= 2 && int.TryParse(w.Substring(0, 2), out day))
                .Select(w => day)
                .Take(2);
            if(days.Count() == 2)
            {
                DateTime startDate = new DateTime(DateTime.Now.Year, month, days.ElementAt(0));
                DateTime endDate = new DateTime(DateTime.Now.Year, month, days.ElementAt(1));
            }
        }
