    using (StreamWriter sw = new StreamWriter(savefile.FileName, 
              false, System.Text.Encoding.Unicode))
    {
         sw.WriteLine("Test line");
         sw.WriteLine("Test line2");
         sw.WriteLine("Test line3");
    }
