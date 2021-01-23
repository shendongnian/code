    foreach (var tr in doc.DocumentNode.SelectNodes("//tr")) {
        var style = tr.SelectSingleNode(".//style");
        //Find the classes and ids with {display:none}
        var matches = Regex.Matches(style.InnerText, @"(\.|#)(.+?)\s*{\s*display\s*:\s*none");
        //Here we will store the classes & ids we'll need to remove
        List<string> classes = new List<string>();
        List<string> ids = new List<string>();
        //Storing the ids and classes
        foreach (Match m in matches) {
            var type = m.Groups[1].Value;
            if (type == ".")
            {
                classes.Add(m.Groups[2].Value);
            }
            else {
                ids.Add(m.Groups[2].Value);
            }
        }
        foreach (var n in tr.SelectNodes(".//*")) {
            if (Remove(n, classes, ids)) {
                n.Remove();
            }
        }
        var proxy = tr.SelectSingleNode("./td[2]/span").InnerText;
        var port = tr.SelectSingleNode("./td[3]").InnerText.Trim('\r', '\n', ' ');
    }
