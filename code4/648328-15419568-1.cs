    public class Product : Comparable
    {
        private int _id;
        private bool _isWhatever;
        private string _something;
        private int _someOtherId;
        public int Id {get { return _id; } set{ _id = value; Add("Id", value); } }
        public bool IsWhatever { get { return _isWhatever; } set{ _isWhatever = value; Add("IsWhatever ", value); } }
        public string Something {get { return _something; } set{ _something = value; Add("Something ", value); } }
        public int SomeOtherId {get { return _someOtherId; } set{ _someOtherId = value; Add("SomeOtherId", value); } }
    }
