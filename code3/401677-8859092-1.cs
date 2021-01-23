    Listing listing1 = new Listing() { NumPages = 2, BrandName = "xx" };
    Listing listing2 = new Listing() { NumPages = 2, BrandName = "xx" };
    Listing listing3 = new Listing() { NumPages = 2, BrandName = "xx" };
    Listing listing4 = new Listing() { NumPages = 3, BrandName = "xxxxx" };
    List<Listing> allListings = new List<Listing>() { listing1, listing2, listing3, listing4 };
    var result = allListings.OrderByDescending(x => x.NumPages).GroupBy(x => x.BrandName).Take(5);
