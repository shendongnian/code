    public static void unprotectPdf(string input, string output) 
    { 
        bool passwordProtected = PdfDocument.IsPasswordProtected(input); 
        if (passwordProtected) 
        { 
            string password = null; // retrieve the password somehow 
     
            using (PdfDocument doc = new PdfDocument(input, password)) 
            { 
                // clear both passwords in order 
                // to produce unprotected document 
                doc.OwnerPassword = ""; 
                doc.UserPassword = ""; 
     
                doc.Save(output); 
            } 
        } 
        else 
        { 
            // no decryption is required 
            File.Copy(input, output, true); 
        } 
    } 
