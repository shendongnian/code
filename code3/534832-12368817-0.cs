        var stringArray = new[]
                              {
                                  "[0]Board1",
                                  "[1]Messages Transmitted75877814",
                                  "[2]ISR Count682900312",
                                  "[3]Bus Errors0",
                                  "[4]Data Errors0",
                                  "[5]Receive Timeouts0",
                                  "[6]TX Q Overflows0",
                                  "[7]No Handler Failures0",
                                  "[8]Driver Failures0",
                                  "[9]Spurious ISRs0"
                              };
        var resultDict = stringArray.Select(s => s.Substring(3))
            .ToDictionary(s =>
                          {
                              int i = s.IndexOfAny("0123456789".ToCharArray());
                              return s.Substring(0, i);
                          },
                          s =>
                          {
                              int i = s.IndexOfAny("0123456789".ToCharArray());
                              return int.Parse(s.Substring(i));
                          });
