    public class Whatever
    {
        [IgnoreDataMember] // this won't be serialized now
        public List<string> Things
        {
            get { return _things; }
        }
    }
