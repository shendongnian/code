    x = orders.Select(y => y.UserDefField) // To just bring down the right values
              .AsEnumerable()
              .Sum(text => {
                       int result;
                       if (text != null) {
                           // We don't care about the return value
                           int.TryParse(text, out result);
                       }
                       return result;
                   });
