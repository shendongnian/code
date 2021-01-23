    List<Parent> myParents = new List<Parent>
                                             {
                                                 new Parent() 
                                                 {
                                                     Prop1 = "1", 
                                                     Prop2 = "2",
                                                     Prop3 = "3", 
                                                     Children = new List<Child>()
                                                            {
                                                                new Child(){ Prop1 = 1, Prop2 = 2, Prop3 = 3 },
                                                                new Child(){ Prop1 = 21, Prop2 = 22, Prop3 = 23 },
                                                                new Child(){ Prop1 = 31, Prop2 = 32, Prop3 = 33 }
                                                            }
                                                 }, 
                                             };
    
                Expression<Func<Parent, int>> GetChildSum =
                    p => p.Children.Where(c => c.Prop1 > 0).Sum(o => o.Prop2);
    
                var v = myParents.Where(w => w.Prop1 == "1").Select(p => GetChildSum.Compile().Invoke(p)).ToList();
    
                Console.WriteLine(v.First());
    
                //output is 56
