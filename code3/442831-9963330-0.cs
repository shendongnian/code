    public ActionResult DownloadPdf()
    {
        var mydoc = ...
        mydoc.GenerateLetter(PdfData);
        byte[] pdf = mydoc.DocumentBytes;
        var reader = new PdfReader(pdf);
        using (var encrypted = new MemoryStream())
        {
            PdfEncryptor.Encrypt(reader, encrypted, true, "abc123", "secret", PdfWriter.ALLOW_SCREENREADERS);
            return File(encrypted.ToArray(), "application/pdf", PdfData.Name + ".pdf");
        }
    }
