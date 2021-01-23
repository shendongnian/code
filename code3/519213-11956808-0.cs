    public class ProfileUserWrapper : DependencyObject
    {
        public ProfileUserWrapper(ProfileUser thebrain) { TheUser = thebrain; }
        public ProfileUser TheUser { get; private set; }
        public Operator User { get { if (_user != null)return _user; return _user = OperatorManager.GetByGuId(TheUser.User_ID); } }
        private Operator _user = null;
    }
