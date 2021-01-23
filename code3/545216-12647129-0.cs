    var dictionary = MyDC.SomeTable
                   .Where(...)
                   .GroupBy(...)
                   .ToDictionary(x => x.Key, x=> x.Count());
    var result = new  MyCountModel
                   {
                      CountSomeByte1 = dictionary[1],
                      CountSomeByte2 = dictionary[2],
                      ....
                      CountSomeByte6 = dictionary[6]
                    });
