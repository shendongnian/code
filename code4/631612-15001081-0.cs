    public MongoMovieHelper()
		{
			var client = new MongoClient(MongoUrl.Create("mongodb://localhost:27017"));
			var server = client.GetServer();
			var db = server["movies"];
			Collection = db.GetCollection<Movie>(typeof (Movie).Name.ToLower());
		}
