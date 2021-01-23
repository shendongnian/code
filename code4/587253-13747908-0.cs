	var c = cboCustomer.SelectedItem as Customer;
	var t = cboTrailer.SelectedItem as Trailer;
	using (var db = new CAPSContainer())
	{
		db.Attach(c);
		c.Trailers.Remove(t);
                db.Trailers.DeleteObject(t);
		db.SaveChanges();
	}
	PopulateTrailers();
