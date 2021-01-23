    public class UserFriendService : RestServiceBase<UserFriendRequest>
    {
    	public override object OnPost(UserFriendRequest request)
    	{
    		// pseudo code 
    		var user = GetUser(request.UserId);
    		var friend = GetUser(request.FriendId); // FriendId is a field in the HTTP body
    		user.Friends.Add(friend);
    		return HttpResult.Status201Created(user, ...);
    	}
    	//...
    }
    
    [Route("/users/{userId}/friends")]
    public class UserFriendRequest
    {
    	public string UserId { get; set; }
    	public string FriendId { get; set; }
    }
