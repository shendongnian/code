    public class UserCollection: KeyedCollection<int, User>
    {
        public UserCollection() : base() {}
        protected override int GetKeyForItem(User user)
        {
            return user.UserID;
        }
    }
