    rows = (
            from tempItem in pagedQuery.ToList()
            let prices = HelpererFunction.GetPrices(tempItem.ID)
            select new
            {
                cell = new string[] {                    
                    tempItem.Name,
                    tempItem.Regular,
                    prices.Item1.ToString(),
                    tempItem.Premium,
                    prices.Item2.ToString(),
                }
            }).ToArray()
