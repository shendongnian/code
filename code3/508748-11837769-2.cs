    public static void ApplyFooter(WordprocessingDocument doc)
          {
              // Get the main document part.
              MainDocumentPart mainDocPart = doc.MainDocumentPart;
    
              FooterPart footerPart1 = mainDocPart.AddNewPart<FooterPart>("r98");
    
    
    
              Footer footer1 = new Footer();
    
              Paragraph paragraph1 = new Paragraph() { };
    
    
    
              Run run1 = new Run();
              Text text1 = new Text();
              text1.Text = "Footer stuff";
    
              run1.Append(text1);
    
              paragraph1.Append(run1);
    
    
              footer1.Append(paragraph1);
    
              footerPart1.Footer = footer1;
    
    
    
              SectionProperties sectionProperties1 = mainDocPart.Document.Body.Descendants<SectionProperties>().FirstOrDefault();
              if (sectionProperties1 == null)
              {
                  sectionProperties1 = new SectionProperties() { };
                  mainDocPart.Document.Body.Append(sectionProperties1);
              }
              FooterReference footerReference1 = new FooterReference() { Type = DocumentFormat.OpenXml.Wordprocessing.HeaderFooterValues.Default,  Id = "r98" };
    
    
              sectionProperties1.InsertAt(footerReference1, 0);
    
          }
