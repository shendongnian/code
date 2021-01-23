    Converter<string, DateTime> converter = (str) =>
                    {
                        DateTime dateTime;
                        if (!DateTime.TryParse(str, out dateTime))
                        {
                           // custom business logic for such cases
                           dateTime = DateTime.MinValue;
                        }
                        return dateTime;
                    };
