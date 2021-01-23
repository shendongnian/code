    var books = docs.Descendants(name)    
                    .Select(x => new
                    {
                        Title = (string)x.Element(ns + "TITLE"),
                        Author = x.Elements(ns + "INTEL_AUTH") // Elements not Element here
                    })
                    .Select(x => new
                    {
                        Title = x.Title,
                        Names = x.Author.Select(i => new
                        {
                            FirstName = (string)i.Element(ns + "FNAME"),
                            MiddleInitial = (string)i.Element(ns + "MNAME"),
                            LastName = (string)i.Element(ns + "LNAME")
                        })
                    })
                    .Select(x => string.Format("{0}: {1}",
                                       x.Title,
                                       x.Names
                                            .Select(i => 
                                                string.Format("{0} {1} {2}", 
                                                    i.FirstName, 
                                                    i.MiddleInitial, 
                                                    i.LastName))
                                           .Aggregate((working, next) => 
                                               working + " | " + next)))
                    .ToList();
