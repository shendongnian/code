     cities = result.Results.Entities.Cast<Address>().ToList();
                        foreach (Address address in cities)
                        {
                            int spaces = (30 - address.City.Length);
                             Stringbuilder s1 = new StringBuilder();
                             s1.append(address.City.Trim());
                            for (int i = 0; i <= spaces; i++)
                            {
                                s1.append(" ");
                            }
                            s1.append(address.PostalCode);
                            customCollection.Add(s1.ToString());
                        }
