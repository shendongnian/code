	//Delete comment
	public PostModel delcomment(int postId, int commentId)
	{
		_client = new MongoClient();
		_database = _client.GetDatabase("post");
		var collection = _database.GetCollection<PostModel>("post");
		var filter = Builders<PostModel>.Filter.Eq("PostId", postId);
		var update = Builders<PostModel>.Update.PullFilter("Comments",
		Builders<Comments>.Filter.Eq("CommentId", commentId));
		collection.FindOneAndUpdate(filter, update);
		var _findResult = collection.Find(filter).FirstOrDefault();
		return _findResult;
	}
