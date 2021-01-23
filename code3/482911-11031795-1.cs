    string WorkingFolder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
    string InputFile = Path.Combine(WorkingFolder, "test.pdf");
    string OutputFile = Path.Combine(WorkingFolder, "test_dec.pdf");//will be created automatically
    //You must provide owner password but not the user password .
    private void DecryptFile(string inputFile, string outputFile)
    {
        string password = @"secret"; // Your Key Here           
        try
        {
            PdfReader reader = new PdfReader(inputFile, new System.Text.ASCIIEncoding().GetBytes(password));
            
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    PdfStamper stamper = new PdfStamper(reader, memoryStream);
                    stamper.Close();
                    reader.Close();
                    File.WriteAllBytes(outputFile, memoryStream.ToArray());
                }
            
        }
        catch (Exception err)
        {
            Console.WriteLine(err.Message);
        }
    }
