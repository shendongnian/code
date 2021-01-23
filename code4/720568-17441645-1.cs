                DateTime yourDate;
                var formats = new[] { "yyyy-MM-dd" };
                if (DateTime.TryParseExact(s, formats, CultureInfo.InvariantCulture, DateTimeStyles.None, out yourDate))
                {
                    dr["Date"] = yourDate;
                }
                else
                {
                    // Do with Invalid DateTime
                }
