    // Post
    public ActionResult NewBooking(AttractionViewModel vm)
    {
        var attractionId = vm.AttractionId; // You have passed back your selected attraction Id.
        return View();
    }
