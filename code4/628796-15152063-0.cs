        PdfReader.unethicalreading = true;
        PdfReader reader = new PdfReader(new FileStream(Statics.PdfUploadLocation + PdfFileName, FileMode.Open, FileAccess.Read));
        XfaForm xfaForm = new XfaForm(reader);
        XDocument xDoc = XDocument.Parse(xfaForm.DomDocument.InnerXml);
        string xfaNamespace = @"{http://www.xfa.org/schema/xfa-template/2.6/}";
        
        List<XElement> formPages = xDoc.Descendants(xfaNamespace + "subform").Descendants(xfaNamespace + "subform").ToList();
        TotalPages = formPages.Count();
        var fieldIndex = 0;
        RawPdfFields = new List<XfaField>();
        for (int page = 0; page < formPages.Count(); page++)
        {
            RawPdfFields.AddRange(formPages[page].Descendants(xfaNamespace + "field")
                        .Select(x => new XfaField
                        {
                            Page = page,
                            Index = fieldIndex++,
                            Name = (string)x.Attribute("name"),
                            Height = GetUnitFromPossibleString((string)x.Attribute("h")),
                            Width = GetUnitFromPossibleString((string)x.Attribute("w")),
                            XPosition = GetUnitFromPossibleString((string)x.Attribute("x")),
                            YPosition = GetUnitFromPossibleString((string)x.Attribute("y")),
                            Reference = GetReference(x.Descendants(xfaNamespace + "traverse")),
                            AssistSpeak = GetAssistSpeak(x.Descendants(xfaNamespace + "speak"))
                        }).ToList());
        }
