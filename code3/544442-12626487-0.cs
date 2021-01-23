     List<object2> newObjects = object1.commaSeparatedListOfIds.Split(',')
                                       .Select(str =>
                                            new object2
                                            {  
                                               id = int.Parse(str),
                                               time = object1.time,
                                               passes = object1.passes
                                            })
                                       .ToList();
