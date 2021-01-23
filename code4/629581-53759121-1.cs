	private static DBEntities context
	{
	get
	{
		if (_context == null)
			_context = new DBEntities(SingleConnection.ConString);
		return _context;
	}
	set { _context = value; }
	}
