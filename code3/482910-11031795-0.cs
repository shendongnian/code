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
