    using (System.IO.StreamReader Reader = new System.IO.StreamReader("C://myfile2.txt"))
    {
          StringBuilder Sb = new StringBuilder();
          string fileContent = Reader.ReadToEnd();
           if (fileContent.Contains("your search text"))
               return true;
           else
               return false;
    }
