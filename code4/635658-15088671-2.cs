    csv.Split(',').Select(item =>
        {
            int parsed;
            if (int.TryParse(item, out parsed))
            {
                return (int?) parsed;
            }
            return (int?) null;
         }
        .Where(item => item.HasValue)
        .Select(item => item.Value);
