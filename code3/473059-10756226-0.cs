    cb.BeginText();
    string text = "";
    text = "F\n";           
    text += "o\n";            
    text += "o";
    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, text, 85, 311, 0);
    cb.EndText();
    
    
    //Create the new page
    PdfImportedPage page = writer.GetImportedPage(reader, 1);
    cb.AddTemplate(page, 0, 0);
    
    Paragraph p = new Paragraph(text);
    document.Add(p);
    
    //Close all streams
    document.Close();
    fs.Close();
    writer.Close();
    reader.Close();
