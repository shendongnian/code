    [HttpPost]
    // My Edit to the code Start -->
    [DataType(DataType.Date)]
    [DisplayFormat(ApplyFormatInEditMode=true, DataFormatString = "{0:d}")]]
    // My Edit to the code Finish <--
    public ActionResult Create(Auction auction)
    {
    // My Edit to the code Start -->
    if(ModelState.IsValid)
    {
    // Only Apply the DateTime if the Action is Valid...
    auction.StartTime = DateTime.Now;
    }
    // My Edit to the code Finish <--
    var db = new EbuyDataContext();
    db.Auctions.Add(auction);
    db.SaveChanges();
    return View(auction);
    }
