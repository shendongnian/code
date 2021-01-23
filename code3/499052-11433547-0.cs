    using (new Impersonator(username, domain,password)) {
          using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Users\Public\TestFolder\WriteLines2.txt"))
          file.WriteLine("asfsd");
          }
     }
