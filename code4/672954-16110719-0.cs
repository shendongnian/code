    System.IO.File.Copy(templatePath, outputPath, true);
    
    using (WordprocessingDocument output = WordprocessingDocument.Open(outputPath, true))
    {
        Body updatedBodyContent = new Body(newWordContent.DocumentElement.InnerXml);
        output.MainDocumentPart.Document.Body = updatedBodyContent;
        output.MainDocumentPart.Document.Save();
    }
    response.Content = new StreamContent(new FileStream(outputPath, FileMode.Open, FileAccess.Read));
    response.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment");
    response.Content.Headers.ContentDisposition.FileName = outputPath;
