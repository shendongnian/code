    var collection = new[]
                            {
                                new { Id = 1 },
                                new { Id = 3 },
                                new { Id = 2 },
                                new { Id = 5 }
                            };
    
    var max = collection.OrderByDescending(x => x.Id).Skip(1).First();
    
    Console.WriteLine(max); // { Id = 3 }
