    var result = allCompanies.Select(c => new object[] {
                        c.LastName, 
                        c.FirstName, 
                        c.Phone, 
                        c.City, 
                        c.PositionApplied, 
                        c.Status, 
                        Convert.ToString(c.CallDate.Value.ToShortDateString()), 
                        Convert.ToString(c.CellOrPager), c.Gender 
                    }).ToList();
