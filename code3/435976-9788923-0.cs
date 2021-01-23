                    foreach (string subfilter in filter.Split(';')) //filter.Split is a string [] which can be iterated through
                    {
                        if (subfilter.ToUpper().StartsWith("PATTERN"))
                        {
                            pattern = subfilter.Split('=')[1];
                        }
                        if (subfilter.ToUpper().StartsWith("START"))
                        {
                            startDate = subfilter.Split('=')[1];
                        }
                        if (subfilter.ToUpper().StartsWith("END"))
                        {
                            endDate = subfilter.Split('=')[1];
                        }
                    }
