	// Example function for update like count add like user  using c#    
	public PostModel LikeComment(LikeModel like)
	{
		PostModel post = new PostModel();
		_client = new MongoClient();
		_database = _client.GetDatabase("post");
		var collection = _database.GetCollection<PostModel>("post");
		var _filter = Builders<PostModel>.Filter.And(
		Builders<PostModel>.Filter.Where(x => x.PostId == like.PostId),
		Builders<PostModel>.Filter.Eq("Comments.CommentId", like.CommentId));
		var _currentLike = collection.Find(Builders<PostModel>.Filter.Eq("PostId", like.PostId)).FirstOrDefault().Comments.Find(f => f.CommentId == like.CommentId).Like;
		var update = Builders<PostModel>.Update.Set("Comments.$.Like", _currentLike + 1);
		collection.FindOneAndUpdate(_filter, update);
		var addUser = Builders<PostModel>.Update.Push("Comments.$.LikeUsers", like.UserId);
		collection.FindOneAndUpdate(_filter, addUser);
		var _findResult = collection.Find(_filter).FirstOrDefault();
		return _findResult;
	}
