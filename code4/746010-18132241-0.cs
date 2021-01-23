    public class CustomList : IReadOnlyList<string>
    {
        private readonly IList<string> _List;
        public CustomList (IList<string> list)
        {
            _List = list;
        }
        public CustomList ()
        {
            _List = new List<string>();
        }
        public static CustomList CustomListBuilder(CustomList customList)
        {
            return new CustomList (customList._List);
        }
    }
