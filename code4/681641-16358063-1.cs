    friendCol = TwitterFriendship.FriendsIds(tokens, options);
    
    Cursor = friendCol.ResponseObject.NextCursor;
    
    foreach (int usuario in friendCol.ResponseObject)
    {
     usuarios newUser = new usuarios();  
     newUser.userId = usuario;
     FollowingList.Add(newUser);
     }
    
    
    for (int i = 0; i < FollowingList.Count -1; i++)
    {
     //Delete by userID
     TwitterResponse<TwitterUser> ans=   TwitterFriendship.Delete(tokens, FollowingList[i].userId);
    
    }
