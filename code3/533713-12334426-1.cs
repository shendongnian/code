    var collection = new[]
                            {
                                new { Id = 1 },
                                new { Id = 3 },
                                new { Id = 2 },
                                new { Id = 5 }
                            };
    
    var secondHighestIdValue = collection.OrderByDescending(x => x.Id).Skip(1).First();
    
    Console.WriteLine(secondHighestIdValue); // { Id = 3 }
