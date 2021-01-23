    var filter = Builders<Book>.Filter.Or(
		Builders<Book>.Filter.Where(p=>p.Title.ToLower().Contains(queryText.ToLower())),
		Builders<Book>.Filter.Where(p => p.Publisher.ToLower().Contains(queryText.ToLower())),
		Builders<Book>.Filter.Where(p => p.Description.ToLower().Contains(queryText.ToLower()))
				);
	List<Book> books = Collection.Find(filter).ToList();
