    public class FriendTeamModel
    {
        public long FriendTeam{ get; set; }
        public IEnumerable<FriendModel> FacebookFriends { get; set; }
        public IEnumerable<FriendModel> TwitterFriends { get; set; }
    }
