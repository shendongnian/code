    [Serializable]
    public class CurrentRecord
    {
        public current current;
    }
    [Serializable]
    public class current
    {
        public region region;
        public category category;
        public int start;
        public int num;
    }
    [Serializable]
    public class region
    {
        public string id;
        public string name;
    }
    [Serializable]
    public class category
    {
        public string id;
        public string name;
        public string abbrev;
    }
