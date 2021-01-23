    var a = allPricesForPgs
            .Where(x => x.PG == c && x.ColourCode == colourInfo.ColourCode)
            .Select(y=> new 
                {
                    Part=y.Part, 
                    Desc=y.Desc, 
                    Price=y.Price*(colourInfo.Discount/100)
                 }
             ));
