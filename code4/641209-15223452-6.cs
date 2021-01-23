        cityList.Sort(delegate (City a, City b)
                      {
                          // -1 => a <  b
                          //  0 => a == b
                          //  1 => a >  b
                          return a.Name.CompareTo(b.Name);
                      });
        // cityList is now sorted by name
        cityList.Sort(delegate (City a, City b)
                      {
                          // -1 => a <  b
                          //  0 => a == b
                          //  1 => a >  b
                          return a.Temperature.CompareTo(b.Temperature);
                      });
        // cityList is now sorted by temperature
