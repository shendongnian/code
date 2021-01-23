    List<MyClass> vats = here.All()
                             .Select(item => new MyClass {
                                         Name = item.Name,
                                         Value = item.Value,
                                     })
                             .ToList();
