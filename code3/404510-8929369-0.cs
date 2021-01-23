    public class ChildMap : SubclassMap<Child>
    {
        public ChildMap ()
        {
            KeyColumn("ParentId")
            Map(x => x.ChildName);
        }
    }
