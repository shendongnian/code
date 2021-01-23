    public class HeaderItem
    {
        public HeaderItem(string headers)
        {
            _headers = headers.ToCharArray().Select(x => x.ToString()).ToArray();
        }
        private string[] _headers = new string[6];
        public int Length
        {
            get { return _headers.Length; }
        }
  
        //...
    }
