    var userIDs = database.Followings.Where(u => u.Follower_id == MY.Id)
                                     .Select(u => u.Following_id)
                                     .ToList(); // ToList(), to make it happen only once
    
    foreach (var userID in userIDs)
    {
         var secondUserIDs = database.Followings.Where(u => u.Follower_id == userID)
                                                .Select(u => u.Following_id)
                                                .Except(userIDs).;
    }
