    string inputString = "This is \"a test\" of the parser.";
    using (MemoryStream ms = new MemoryStream(Encoding.ASCII.GetBytes(inputString)))
    {
        using (Microsoft.VisualBasic.FileIO.TextFieldParser tfp = new TextFieldParser(ms))
        {
            tfp.Delimiters = new string[] { " " };
            tfp.HasFieldsEnclosedInQuotes = true;
            string[] output = tfp.ReadFields();
            for (int i = 0; i < output.Length; i++)
            {
                Console.WriteLine("{0}:{1}", i, output[i]);
            }
        }
    }
