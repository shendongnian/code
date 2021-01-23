    var elems = webBrowser1.Document.GetElementsByTagName("input");
    foreach (var elem in elems)
    {
        var value = elem.GetAttribute("value");
        if (string.IsNullOrEmpty(value) && value.Trim().ToLower().Equals("type102"))
        {
            MessageBox.Show(value);
        }
    }
