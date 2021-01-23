    rows = (
                    from tempItem in pagedQuery.ToList()
                    let price = HelpererFunction.GetPrice(tempItem.ID)
                    select new
                    {
                        cell = new string[] {                    
                            tempItem.Name,
                            tempItem.Regular,
                            price[0].ToString() ,
                            tempItem.Premium,
                            price[1].ToString() ,
                        }
                    }).ToArray()
