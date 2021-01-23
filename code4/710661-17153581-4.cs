     var values =
         list.Select(
             s => {
                 double value;
                 if(s == null) {
                      return new { Parseable = true, Value = (double?)null) };
                 }
                 else if(!Double.TryParse(s, out value)) {
                      return new { Parseable = false, Value = (double?)null) };
                 }
                 else {
                      return new { Parseable = true, Value = value };
                 }
          )
          .Where(x => x.Parseable)
          .Select(x => x.Value)
          .ToList();
