    var query = dbase.userfriendsrequests.Select(user => new 
                                                 { 
                                                  UserID = user.FriendID,
                                                  FriendID = user.UserID
                                                 }
                     .Except(
                       dbase.userfriends.Select(frnd => new 
                                                 { 
                                                  UserID = frnd.FriendID,
                                                  FriendID = frnd.UserID
                                                 });
