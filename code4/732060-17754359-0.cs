    public IEnumerable<BookingView> GetAllBookings()
    {
        var a = from o in dre.Tickets select o;
        return a.AsEnumerable().Select(Map).ToList();
    }
    
    private BookingView Map(Ticket ticket)
    {
    	var bookingView = new BookingView();
    	//mapping code goes here
    	return bookingView;
    }
