    var elems = webBrowser1.Document.GetElementsByTagName("input");
    var myInputElement = elems.First(e => !string.IsNullOrEmpty(e) && e.Trim().ToLower().Equals("type102"));
    foreach (var elem in elems)
    {
        var value = elem.GetAttribute("value");
        if (string.IsNullOrEmpty(value) && value.Trim().ToLower().Equals("type102"))
        {
            MessageBox.Show(value);
            break;
        }
    }
