            onQuotes.Sort((d1, d2) =>
            {
                if (d1.WonDt.HasValue && d2.WonDt.HasValue)
                {
                    return d1.WonDt.Value.CompareTo(d2.WonDt.Value);
                }
                if (!d1.WonDt.HasValue && !d2.WonDt.HasValue)
                {
                    return 0;
                }
                return d1.WonDt.HasValue ? 1 : -1;
            });
