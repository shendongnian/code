            var someArray = new List<TestClass>
                                {
                                    new TestClass {Name = "Some Class", TypeEnum = "Default"},
                                    new TestClass {Name = "Some Class", TypeEnum = "Other"},
                                    new TestClass {Name = "Some Class 2", TypeEnum = "Default"},
                                    new TestClass {Name = "Some Class 2", TypeEnum = "Other"},
                                    new TestClass {Name = "Some Class 3", TypeEnum = "Default"}
                                };
            string myEnum = "Other";
            var result = someArray.GroupBy(t => t.Name).
                Select(
                    t =>
                    new TestClass
                        {
                            Name = t.Key,
                            TypeEnum = t.Any(w => w.TypeEnum == myEnum) ?
                                       t.FirstOrDefault(s => s.TypeEnum == myEnum).TypeEnum :
                                       t.FirstOrDefault(s => s.TypeEnum == "Default").TypeEnum
                        });
