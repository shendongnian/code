    csv.Split(',').SelectMany(item =>
        {
            int parsed;
            if (int.TryParse(item, out parsed))
            {
                return new[] {parsed};
            }
            return Enumerable.Empty<int>();   
        }
