    public class FacebookFriends
    {
        public string FriendID { get; set; }
        public string FriendName { get; set; }
        public string PicURLSquare { get; set; }
        public string ProfileLink { get; set; }
        //Gets your FB friends that are NOT currently using this application so you can invite them
        public static IEnumerable<FacebookFriends> GetFriendsNotUsingApp()
        {
            string strQuery = "SELECT uid, name, pic_square, link FROM user WHERE uid IN (SELECT uid2 FROM friend WHERE uid1=me()) AND NOT is_app_user";
            FacebookSDKInterface objFQL = new FacebookSDKInterface();
            dynamic objFNU = objFQL.FBFQL(strQuery);
            if (objFQL != null) // shouldn't you check objFNU for being null here instead?
            {
                return objFNU.data.Select(row => new FacebookFriends()
                    {
                        FriendID = row.uid,
                        FriendName = row.name,
                        PicURLSquare = row.pic_square,
                        ProfileLink = row.link
                    }).OrderByDescending(p => p.FriendName);
            }
            else
            {
                return new List<FacebookFriends>();
            }
        } //Get FB Friends not already using this app
    }
