    public void DecodeWithString() {
       System.IO.StreamReader inFile;    
       string base64String;
    
       try {
          char[] base64CharArray;
          inFile = new System.IO.StreamReader(inputFileName,
                                  System.Text.Encoding.ASCII);
          base64CharArray = new char[inFile.BaseStream.Length];
          inFile.Read(base64CharArray, 0, (int)inFile.BaseStream.Length);
          base64String = new string(base64CharArray);
       }
       catch (System.Exception exp) {
          // Error creating stream or reading from it.
          System.Console.WriteLine("{0}", exp.Message);
          return;
       }
    
       // Convert the Base64 UUEncoded input into binary output. 
       byte[] binaryData;
       try {
          binaryData = 
             System.Convert.FromBase64String(base64String);
       }
       catch (System.ArgumentNullException) {
          System.Console.WriteLine("Base 64 string is null.");
          return;
       }
       catch (System.FormatException) {
          System.Console.WriteLine("Base 64 string length is not " +
             "4 or is not an even multiple of 4." );
          return;
       }
    
       // Write out the decoded data.
       System.IO.FileStream outFile;
       try {
          outFile = new System.IO.FileStream(outputFileName,
                                     System.IO.FileMode.Create,
                                     System.IO.FileAccess.Write);
          outFile.Write(binaryData, 0, binaryData.Length);
          outFile.Close();
       }
       catch (System.Exception exp) {
          // Error creating stream or writing to it.
          System.Console.WriteLine("{0}", exp.Message);
       }
    }
