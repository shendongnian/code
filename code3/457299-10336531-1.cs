    doc.Open();
    //Sample HTML
    StringBuilder stringBuilder = new StringBuilder();
    stringBuilder.Append(@"<p>This is a test: <strong>α,β</strong></p>");
    //Path to our font
    string arialuniTff = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "ARIALUNI.TTF");
    //Register the font with iTextSharp
    iTextSharp.text.FontFactory.Register(arialuniTff);
    //Create a new stylesheet
    iTextSharp.text.html.simpleparser.StyleSheet ST = new iTextSharp.text.html.simpleparser.StyleSheet();
    //Set the default body font to our registered font's internal name
    ST.LoadTagStyle(HtmlTags.BODY, HtmlTags.FACE, "Arial Unicode MS");
    //Set the default encoding to support Unicode characters
    ST.LoadTagStyle(HtmlTags.BODY, HtmlTags.ENCODING, BaseFont.IDENTITY_H);
    //Parse our HTML using the stylesheet created above
    List<IElement> list = HTMLWorker.ParseToList(new StringReader(stringBuilder.ToString()), ST);
    //Loop through each element, don't bother wrapping in P tags
    foreach (var element in list) {
        doc.Add(element);
    }
    doc.Close();
