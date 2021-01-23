    Enumerable.Range(0, items.Max(x => x.Count()))
                          .ToList()
                          .ForEach(x =>
                                       {
                                                items
                                                .Where(lstChosen => lstChosen.Count()-1 >= x)
                                                .Select(lstElm => lstElm.ElementAt(x))
                                                .ToList().ForEach(z => Console.WriteLine(z));
                                       });
