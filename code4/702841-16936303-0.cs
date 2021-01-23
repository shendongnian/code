    public partial class CODE
    {
        public struct Status
        {
            public const long Registered    = 5;
            public const long Active        = 6;
            public List<long> StatusList;
            public Status()
            {
                StatusList = new Dictionairy<int, long>();
                StatusList.Add(Registered);
                StatusList.Add(Active);
            }
        }
    }
