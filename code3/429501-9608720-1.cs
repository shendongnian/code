    public class barlist
    {
        private string barName;
        private string barLocation;
        public static List<barlist> myBarArray = new List<barlist>();
        public string Name
        {
            get { return barName; }
            set { barName = value; }
        }
        public barlist()
        {
          myBarArray.Add(this);
        }
        public string Location
        {
            get { return barLocation; }
            set { barLocation = value; }
        }
    }  
