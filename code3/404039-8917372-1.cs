    x = orders.Select(y => y.UserDefField) // To just bring down the right values
              .AsEnumerable()
              .Sum(text => {
                       int result;
                       // We don't care about the return value... and
                       // it even handles null input. (In any error condition,
                       // "result" will be 0 afterwards.)
                       int.TryParse(text, out result);
                       return result;
                   });
