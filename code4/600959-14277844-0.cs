                // Add a new main document part. 
                package.AddMainDocumentPart();
                // Create the Document DOM. 
                package.MainDocumentPart.Document = new Document();
                Body bd = package.MainDocumentPart.Document.Body = new Body();
                 
                //write a first paragraph on two columns
                var paragrap1 = new Paragraph();
                var paragraphSectionProperties = new ParagraphProperties(new SectionProperties());
                var paragraphColumns = new Columns();
                paragraphColumns.EqualWidth = true;
                paragraphColumns.ColumnCount = 2;
                
                paragraphSectionProperties.Append(paragraphColumns);
                paragrap1.Append(paragraphSectionProperties);
                paragrap1.Append(new Run(new Text(str)));
                bd.AppendChild(paragrap1);
                
                //write another paragraph without paragraph properties
                bd.Append(new Paragraph(new Run(new Text(str))));
                //set the body properties default three columns
                var sectionProperties = new SectionProperties();
                var columns = new Columns();
                columns.EqualWidth = true;
                columns.ColumnCount = 3;
                
                sectionProperties.Append(columns);
                bd.Append(sectionProperties);
    
                package.MainDocumentPart.Document.Save();
