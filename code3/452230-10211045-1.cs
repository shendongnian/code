    foreach (var node in nodes)
    {
        var style = node.Attributes["style"].Value;
        if (colorRegex.IsMatch(style))
        {
            var color = colorRegex.Match(style).Value;
            node.InnerHtml =
                HttpUtility.HtmlEncode("<" + color + ">") +
                node.InnerHtml +
                HttpUtility.HtmlEncode("</" + color + ">");
        }
    }
