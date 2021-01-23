    public class ProfilePics : System.Collections.IEnumerable
    {
        public string status { get; set; }
        public string filename { get; set; }
        public bool mainpic { get; set; }
        public string fullurl { get; set; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            yield break;
        }
    }
