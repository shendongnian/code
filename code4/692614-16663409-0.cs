     using (FileStream fs = new FileStream(@"C:\SourceDatatoedit.csv", FileMode.Open,       FileAccess.Read))
    {
      fs.Seek(offset, SeekOrigin.Begin);
      StreamReader sr = new StreamReader(fs);
      {
        while (!sr.EndOfStream && fs.CanRead)
        {
            streamsample = sr.ReadLine();
            numoflines++;
        }// end while block
      }//end stream sr block
    }
