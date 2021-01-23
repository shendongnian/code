    ...
    class CustomClass
            {
                public string Name { get; set; }
                public DateTime Date { get; set; }
            }
    ...
    var customCollection = (from human in humans
                                        select new CustomClass
                                            {
                                                Name = human.Name,
                                                Date = human.DateOfBirth,
                                            }
                                            ).Union(from animal in animals
                                                    select new CustomClass
                                                        {
                                                            Name = animal.Name,
                                                            Date = animal.DateOfBirth,
                                                        }).OrderBy(x => x.Date);
    
    
                foreach (CustomClass customItem in customCollection)
                    Console.WriteLine(String.Format("Date: {0}, Name: {1}", customItem.Date, customItem.Name));
    
    ...
