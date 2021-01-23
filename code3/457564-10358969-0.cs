	public void Handle(BookUpdated msg)
	{
		var book = Session.Load<Book>(msg.BookId);
		var alerts = Session.Query<Alerts>()
			.Search(x=>x.Keywords, book.Description)
			.ToList();
		// alert for book
	}
