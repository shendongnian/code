    using (Document doc = new Document(PageSize.A4, 0, 0, 0, 0))
    {
        using (FileStream stream = new FileStream(targetPath, FileMode.Create))
        {
            PdfWriter.GetInstance(doc, stream);
            doc.Open();
            var font = FontFactory.GetFont("Courier", 10);
            var paragraph = new Paragraph(sb.ToString(), font);
            doc.Add(paragraph);
            doc.Close();
        }
    }
