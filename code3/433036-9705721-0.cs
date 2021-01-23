    var query = docs.Descendants(name)
        .Select(x => new {
            Title = (string)x.Element(ns + "TITLE"),
            Authors = x.Elements(ns + "INTEL_AUTH")
         })
        .Select(x => new {
            Title = x.Title,
            Authors = x.Authors.Select(a => new {
                FirstName = (string) a.Element(ns+"FNAME"),
                MiddleInitial = (string) a.Element(ns+"MNAME"),
                LastName = (string) a.Element(ns+"LNAME")
            })
         });
 
     foreach (var book in query)
     {
         Console.WriteLine("{0}:", book.Title);
         foreach (var author in book.Authors)
         {
             Console.WriteLine("  {0} {1} {2}",
                               author.FirstName, author.MiddleInitial,
                               author.LastName);
         }
     }
