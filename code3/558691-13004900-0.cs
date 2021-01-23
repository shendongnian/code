     string strInput = "YourString";
     Regex regex = new Regex("Your Regex to match");
     var m = regex.Match(strInput);
     if (m.Success)
          {
              foreach (var matches in regex.Matches(strInput))
               {
                  if (m.Success)
                     {
                         Console.WriteLine(m.Index);
                     }
                     m = m.NextMatch();
                }
            }
        
