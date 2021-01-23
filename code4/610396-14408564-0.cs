    using DocumentFormat.OpenXml;
    using DocumentFormat.OpenXml.Wordprocessing;
    ...
    Paragraph newParagraph = new Paragraph();
    ParagraphProperties paraProperties = new ParagraphProperties();
    ParagraphBorders paraBorders = new ParagraphBorders();
    BottomBorder bottom = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)12U, Space = (UInt32Value)1U };
    paraBorders.Append(bottom);
    paraProperties.Append(paraBorders);
    newParagraph.Append(paraProperties);
