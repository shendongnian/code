            var result = db.LengthDatas
                .ToList()
                .Select(c =>
                {
                    decimal d;
                    Decimal.TryParse(c.AbsoluteCounter, out d);
                    return d;
                })
                .Max();
