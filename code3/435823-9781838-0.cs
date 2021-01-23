    public class ProfilePic
    {
        public string status { get; set; }
        public string filename { get; set; }
        public bool mainpic { get; set; }
        public string fullurl { get; set; }
    
    }
    
    public class ProfilePics : IEnumerable<ProfilePic>
    {
        private pics = new List<ProfilePic>();
    
        // ... implement the IEnumerable members
    }
