    var cities = ((IEnumerable<City>)Enum.GetValues(typeof(City)))
                                         .Select(x => 
                                             new 
                                             {
                                                 Value =  (int)x,
                                                 Text = x.ToString()
                                             });
