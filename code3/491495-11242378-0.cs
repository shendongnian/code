      using (StreamReader sr = 
                 File.OpenText(System.IO.Path.GetFullPath("OrderEmailBody.txt")))
      {
          String input;
          while ((input = sr.ReadLine()) != null)
          {
              emailBody += input;
              email += Environment.NewLine;
          }
      }
