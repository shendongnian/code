    public class ErrorList
    {
        private Dictionary<int, List<string>> errorList = new Dictionary<int, List<string>>();
        ... some methods that fill the errorList field
        public IEnumerator<KeyValuePair<int, List<string>>> GetEnumerator()
        {
            return errorList.GetEnumerator();
        }
    }
