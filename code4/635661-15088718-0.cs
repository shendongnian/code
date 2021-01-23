    csv.Split(',')
        .Where(item => Char.IsNumber(item))
        .Select(item =>
         {
            int parsed;
            if (int.TryParse(item, out parsed))
            {
                return parsed;
            }
            continue; //is not allowed here
         }).ToList();
