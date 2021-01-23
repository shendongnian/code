     //Mock function to simulate creating 5 objects with 'CreateArrayOb' function
            public void CreatingObjects()
            {
                var lst = new List<object>();
                for (var x = 0; x < 5; x++)
                {
                    lst.Add(CreateArrayOb(new string[] {"Path" + x, "Dir" + x, "Path" + x}));
                }
            }
            public object CreateArrayOb(object[] vals)
            {
                if (vals != null && vals.Any())
                {
                    //Switch cases in the event that you would like to alter the object type returned
                    //based on the number of parameters sent
                    switch (vals.Count())
                    {
                        case 0:
                            break;
                        case 1:
                            break;
                        case 2:
                            break;
                        case 3:
                            return new { path = vals.ElementAt(0), pathDir = vals.ElementAt(1), name = vals.ElementAt(2) };
                    }
                    
                }
                return null;
            }
