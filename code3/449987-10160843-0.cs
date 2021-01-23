     void doLinq(params string[] selectors) // checking two expressions for equality is messy, so I used strings
         foreach (var grp in collection.GroupBy(
              item => new { 
                  Col1 = (selectors.Contains("Col1") ? item.Col1 : String.Empty),
                  Col2 = (selectors.Contains("Col2") ? item.Col2 : String.Empty)
                  // need to add a line for each column :(
              }))
         {
              string[] grouping = (new string[]{grp.Key.Col1, grp.Key.Col2 /*, ...*/ }).Where(s=>!s.IsNullOrEmpty()).ToArray();
              Debug.Write("Grouping by " + String.Join(" and ", grouping)+ ": ");
              Debug.WriteLine(grp.Count() + " rows");
         }
     }
