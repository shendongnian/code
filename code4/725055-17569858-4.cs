    var result = Regex.Replace(input, @"([^,].*?)\d+(?=,)",
        (match1) =>
        {
            var value = match1.Value;
            if (filter.Any(f => match1.Value.StartsWith(f)))
            {
                value = Regex.Replace(match1.Value, @"(?<=)\d+",
                    (match2) =>
                    {
                        return (Convert.ToInt32(match2.Value) + 1)
                            .ToString()
                            .PadLeft(match2.Value.Length, '0');
                    });
            }
            return value;
        });
