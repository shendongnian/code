    public interface ISubGroup
    {}
    class Group
    {
        private class SubGroup : ISubGroup
        {
            public SubGroup(int param)
            {
            }
        }
        List<SubGroup> list;
        public Group(int param)
        {
            list = new List<SubGroup>();
        }
        public ISubGroup createChild(int args)
        {
            return new SubGroup(args); 
        }
    }
