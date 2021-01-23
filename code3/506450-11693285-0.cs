    try
            {
                FacebookSDKInterface objFQL = new FacebookSDKInterface();
                dynamic objFNU = objFQL.FBFQL(strQuery);
                if (objFNU != null) // shouldn't you check objFNU for being null here instead?
                {
                   IEnumerable<dynamic> objFNUdata = (IEnumerable<dynamic>)objFNU.data; // explicit cast might not be necessary
                   IEnumerable<FacebookFriends> objMyFriends =
                   from row in objFNUdata
                   select new FacebookFriends()
                   {
                       FriendID = row.uid,
                       FriendName = row.name,
                       PicURLSquare = row.pic_square,
                       ProfileLink = row.profile_url
                   };
                   objMyFriends = objMyFriends.OrderBy(p => p.FriendName);
                   return objMyFriends;
                }
                else
                {
                    return new List<FacebookFriends>();
                }
            }
            catch (Exception ex)
            {
                return new List<FacebookFriends>();
            }
