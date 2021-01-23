    rows = (
                    from tempItem in pagedQuery.ToList()
                    let price = HelpererFunction.GetPrice(tempItem.ID, false).ToString()
                    select new
                    {
                        cell = new string[] {                    
                            tempItem.Name,
                            tempItem.Regular,
                            price ,
                            tempItem.Premium,
                            price ,
                        }
                    }).ToArray()
