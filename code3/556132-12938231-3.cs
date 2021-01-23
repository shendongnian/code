    rows = (
                    from tempItem in pagedQuery.ToList()
                    let prices = HelpererFunction.GetPrice(tempItem.ID)
                    select new
                    {
                        cell = new string[] {                    
                            tempItem.Name,
                            tempItem.Regular,
                            prices[0].ToString() ,
                            tempItem.Premium,
                            prices[1].ToString() ,
                        }
                    }).ToArray()
