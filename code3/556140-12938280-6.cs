    rows = (
            from tempItem in pagedQuery.ToList()
            let prices = HelpererFunction.GetPrices(tempItem.ID)
            select new
            {
                cell = new string[] {                    
                    tempItem.Name,
                    tempItem.Regular,
                    prices.Price.ToString(),
                    tempItem.Premium,
                    prices.PremiumPrice.ToString(),
                }
            }).ToArray()
