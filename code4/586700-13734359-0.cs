    var newArrivals = new ThingWithListings();
    newArrivals.Listings = new List<Listing>();
    newArrivals.Listings.Add(
        new Listing()
        {
            creation = DateTime.Now,
            ListingData = new ListingData()
            {
                listing_id = 1
            }
        });
    //another Listing with the same ListingData listing_id
    newArrivals.Listings.Add(
        new Listing()
        {
            creation = DateTime.Now,
            ListingData = new ListingData()
            {
                listing_id = 1
            }
        });
    //dummy id generator
    int counter = 1;
    using (var ctx = new Database1Entities())
    {
        //get the ListingData from the current db context
        var dbListingData = ctx.ListingData;
        // the new arrivals
        foreach (Listing item in newArrivals.Listings)
        {
            //get the listing_id of a new arrival's ListingData
            int id = item.ListingData.listing_id;
            //get the ListingData from the db, if it exists
            var listingDataFromDb = dbListingData.FirstOrDefault(i => i.listing_id == id);
            //if not, create it and add it to the db
            if (listingDataFromDb == null)
            {
                listingDataFromDb = new ListingData()
                    {
                        //use the new arrival's listing_id
                        listing_id = item.ListingData.listing_id
                    };
                ctx.ListingData.Add(listingDataFromDb);
                ctx.SaveChanges();
            }
            //add the Listing by using the listingDataFromDb, which now references the db ListingData
            ctx.Listing.Add(new Listing()
            {
                id = counter++,
                creation = item.creation,
                ListingData = listingDataFromDb
            });
            ctx.SaveChanges();
        }
    }
