    public class Friend
    {
        public static readonly int MaxDepth = 8; // prevent more than 8 recursions
        private List<Friend> myFriends_ = new List<Friend>();
        // private implementation
        private void InternalFriends(int depth, int currDepth, List<Friend> list)
        {
            // add friends of THIS one here.  Probably want to use "Contains" to ensure you
            // do not add duplicates.  Also assumes Friend would implement an interface to do this.  For brevity, I just add them all
            list.AddRange(myFriends_);
 
            if(currDepth <= depth)
            {
                foreach(Friend f in myFriends_)
                    f.InternalFriends(depth, depth + 1, list); // we can all private functions here.
            }
        } // eo InternalFriends
        public List<Friend> GetFriendsOfFriend(int depth)
        {
            List<Friend> ret = new List<Friend>();
            InternalFriends(depth < MaxDepth ? depth : MaxDepth, 1, ret);
            return ret;
        }  // eo getFriendsOfFriend
    } // eo class Friend
