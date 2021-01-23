    WordprocessingDocument wordDocument = WordprocessingDocument.Create(FinalPath, WordprocessingDocumentType.Document);
    MainDocumentPart mainPart = wordDocument.AddMainDocumentPart();
    mainPart.Document = new Document();
    Body body = mainPart.Document.AppendChild(new Body());
    Paragraph para = body.AppendChild(new Paragraph());
    Run run = para.AppendChild(new Run());
    run.AppendChild(new Text("Executive Summary"));
    StyleDefinitionPart styleDefinitionsPart = wordDocument.AddStylesDefinitionPart();
    Styles styles = styleDefinitionsPart.Styles;
    Style style = new Style() {
      Type = StyleValues.Paragraph, 
      StyleId = styleid, 
      CustomStyle = true
    };
    StyleName styleName1 = new StyleName() { Val = "Heading1" };
    style.Append(styleName1);
    StyleRunProperties styleRunProperties1 = new StyleRunProperties();
    styleRunProperties1.Append(new Bold);
    styleRunProperties1.Append(new Italic());
    styleRunProperties1.Append(new RunFonts() { Ascii = "Lucida Console" };);
    styleRunProperties1.Append(new FontSize() { Val = "24" });  // Sizes are in half-points. Oy!
    style.Append(styleRunProperties1);
    styles.Append(style);
    pPr.ParagraphStyleId = new ParagraphStyleId(){ Val = "Heading1" };
    para.PrependChild<ParagraphProperties>(new ParagraphProperties());
