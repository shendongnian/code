    [HttpPost]
    public ActionResult CreateBooking(BookingViewModel bookingModel)
    {
        if (bookingModel.UserId == User.Identity.Name)
        {
            // proceed with booking
            return View("BookingComplete", bookingModel);
        }
        else
        {
            // add model state error
        }
        return View(bookingModel)
    }
