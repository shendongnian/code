    using (MemoryStream m = new MemoryStream())
    {
    	m.Write(mydoc.DocumentBytes, 0, mydoc.DocumentBytes.Length);
    	m.Seek(0, SeekOrigin.Origin);
    
    	string OutputFile = Path.Combine(WorkingFolder, "TestingOut1.pdf");
        using (Stream output = new FileStream(OutputFile, FileMode.Create, FileAccess.Write, FileShare.None))
        {
            PdfReader reader = new PdfReader(m);
            PdfEncryptor.Encrypt(reader, output, true, "abc123", "secret", PdfWriter.ALLOW_SCREENREADERS);
        }
    }  
