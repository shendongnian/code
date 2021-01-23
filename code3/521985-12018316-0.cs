    // Setup the parameters
    string fileName = "C:\\example.pdf";
    string licenseKey = "...";
    
    // Create the library
    QuickPDFAX0712.PDFLibrary qp = new QuickPDFAX0712.PDFLibrary();
    
    // Unlock the library
    qp.UnlockKey(licenseKey);
    qp.DrawHTMLText(40, 760, 200, "Here is some <b>bold</b>, <i>italic</i> and <u>underlined</u> text");
    qp.DrawHTMLText(40, 730, 200, "<ul><li>This</li><li>is</li><li>a</li><li>bullet</li><li>list</li></ul>");
    
    // Save the new PDF that you've created.
    qp.SaveToFile(fileName);
