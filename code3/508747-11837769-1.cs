    public static void ApplyHeader(WordprocessingDocument doc)
          {
              // Get the main document part.
              MainDocumentPart mainDocPart = doc.MainDocumentPart;
    
              HeaderPart headerPart1 = mainDocPart.AddNewPart<HeaderPart>("r97");
              
    
           
                Header header1 = new Header();
    
                Paragraph paragraph1 = new Paragraph(){  };
    
            
    
                Run run1 = new Run();
                Text text1 = new Text();
                text1.Text = "Header stuff";
    
                run1.Append(text1);
    
                paragraph1.Append(run1);
    
                
                header1.Append(paragraph1);
                
                headerPart1.Header = header1;
    
    
    
                SectionProperties sectionProperties1 = mainDocPart.Document.Body.Descendants<SectionProperties>().FirstOrDefault();
                if (sectionProperties1 == null)
                {
                    sectionProperties1 = new SectionProperties() { };
                    mainDocPart.Document.Body.Append(sectionProperties1);
                }
                HeaderReference headerReference1 = new HeaderReference() { Type = HeaderFooterValues.Default, Id = "r97" };
                
    
                sectionProperties1.InsertAt(headerReference1,0);
    
            }
