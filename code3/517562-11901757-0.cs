    string line = string.Empty;
    using (StreamReader sr = new StreamReader("C:\\message.txt"))
    {
      while ((line = sr.ReadLine()) != null)
      {
          if (line.IndexOf(m1) > 0 &&
          line.IndexOf(m2)  )
          {
             var result = line.Replace(m2, "READ");
          }
       }
    }
