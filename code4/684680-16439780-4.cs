    public interface ISubGroup
    {}
    internal class SubGroup : ISubGroup
        {
            public SubGroup(int param)
            {
            }
        }
    public class Group
    {
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
