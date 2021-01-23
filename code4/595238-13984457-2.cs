    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;
    
    class Production
    {
       public string Name;
       public string[] Components;
    
       public static IEnumerable<Production> Parse(string contents)
       {
          var rdr = new System.IO.StringReader(contents);
          string line;
          var productions = new List<Production>();
          while(null != (line = rdr.ReadLine()))
          {
             if(string.IsNullOrEmpty(line))
                continue;
             productions.Add(ParseOne(line));
          }
    
          return productions;
       }
    
       public static Production ParseOne(string line)
       {
          var parts = line.Split(new [] {' '}, StringSplitOptions.RemoveEmptyEntries);
          return new Production{Name = parts[0], Components = parts.Skip(2).ToArray()};
       }
    
    }
