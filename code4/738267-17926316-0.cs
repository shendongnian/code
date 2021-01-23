    public ActionResult Compare(int id, string orderBy)
    {
        var productsList = Products.BuildIndividualProductComparisonList(id);
        var product = Products.BuildToCompare(id);
        var organizedProductsList = null;
    
    
            switch (orderBy)
            {
                case "lowestToBiggest":
                    organizedProductsList = 
                        productsList.OrderBy(x => x.minProductPrice);
                    break;
                case "biggestToLowest":
                    organizedProductsList = 
                        productsList.OrderBy(x => x.maxProductPrice);
                    break;
                default:
                    organizedProductsList = 
                        productsList.OrderBy(x => x.minProductPrice);
                    break;
            }
    
        ComparisonViewModel comparisonViewModel =
            new ComparisonViewModel
            {
                Product = product,
                ProductList = organizedProductsList
            };
    
        return View(comparisonViewModel);
    }
