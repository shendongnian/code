    private void ReplaceTags(Document document, SomeModel model)
    {
        var textBoxContents = document.Descendants<TextBoxContent>().ToList();
        foreach (var textBoxContent in textBoxContents)
        {
            ReplaceTag(textBoxContent, model);
        }
    }
    
    private void ReplaceTag(TextBoxContent textBoxContent, SomeModel model)
    {
        var tag = textBoxContent.InnerText.Trim();
        if (!tagsTomValues.ContainsKey(tag)) return;
        var valueSelector = tagsTomValues[tag];
        textBoxContent.RemoveAllChildren();
        var paragraph = textBoxContent.AppendChild(new Paragraph());
        var run = paragraph.AppendChild(new Run());
        run.AppendChild(new Text(valueSelector(model)));
    }
    
    // called in the ctor
    private static void IntializeTags(IDictionary<string, Func<SomeModel, string>> dictionary)
    {
        dictionary.Add("<<IH.Name>>", m => string.Format("{0} {1}", m.FirstName, m.LastName));
    }
