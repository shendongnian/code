    void CreateWordDocumentUsingMSWordStyles(string outputPath, string templatePath)
    {
        // create a copy of the template and open the copy
        System.IO.File.Copy(templatePath, outputPath, true);
    
        using (var document = WordprocessingDocument.Open(outputPath, true))
        {
            document.ChangeDocumentType(WordprocessingDocumentType.Document);
    
            var mainPart = document.MainDocumentPart;
            var settings = mainPart.DocumentSettingsPart;
    
            var templateRelationship = new AttachedTemplate { Id = "relationId1" };
            settings.Settings.Append(templateRelationship);
    
            var templateUri = new Uri("c:\\anything.dotx", UriKind.Absolute); // you can put any path you like and the document styles still work
            settings.AddExternalRelationship("http://schemas.openxmlformats.org/officeDocument/2006/relationships/attachedTemplate", templateUri, templateRelationship.Id);
                    
            // using Title as it would appear in Microsoft Word
            var paragraphProps = new ParagraphProperties();
            paragraphProps.ParagraphStyleId = new ParagraphStyleId { Val = "Title" };
                    
            // add some text with the "Title" style from the "Default" style set supplied by Microsoft Word
            var run = new Run();
            run.Append(new Text("My Title!"));
    
            var paragraph = new Paragraph();
            paragraph.Append(paragraphProps);
            paragraph.Append(run);
    
            mainPart.Document.Body.Append(paragraph);
    
            mainPart.Document.Save();
        }
    }
