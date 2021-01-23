       // Leaving off all public/private/error detection stuff
       class ColumnDef  
       {
            string Name { set; get; } 
            int FirstCol { set; get; }
            int LastCol { set; get; }
       }
       ColumnDef[] report = new ColumnDef[] 
       {
             { Name = "ColA",
               FirstCol = 0,
               LastCol = 2
             },
             /// ... and so on for each column
       }
       IDictionary<string, string> ParseDataLine(string line) 
       {
           var dummy = new Dictionary<string, string>();
           foreach (var c in report) 
           {
              dummy[c.Name] = line.Substring(c.FirstCol, c.LastCol).Trim();
           }
       }
