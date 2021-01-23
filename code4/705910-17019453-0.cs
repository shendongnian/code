      var allDates = new[] 
                    { 
                        "2013-05-02 07:45:15",
                        "2013-05-02 09:25:01",
                        "2013-05-02 18:15:15",
                        "2013-05-04 08:45:15",
                        "2013-05-04 17:45:35" 
                    };
    
                var earliest = allDates.GroupBy(date => Convert.ToDateTime(date).Day).Select(g => new
                    {
                        first = g.Min(),
                        last = g.Max()
                    });
