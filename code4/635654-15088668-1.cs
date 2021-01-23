    csv.Split(',')
       .Select(item =>
               {
                   int parsed;
                   return new { IsNumber = int.TryParse(item, out parsed), 
                                Value = parsed };
               })
       .Where(x => x.IsNumber)
       .Select(x => x.Value);
