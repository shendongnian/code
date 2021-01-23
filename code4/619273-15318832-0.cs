    public class LookupList : IEnumerable<string>
    {
        private readonly IEnumerable<string> _source;
        private Dictionary<string, List<string>> _referenceDic;
        public LookupList(IEnumerable<string> source, Dictionary<string, List<string>> referenceDic)
        {
            _source = source;
            _referenceDic = referenceDic;
        }
        public IEnumerator<string> GetEnumerator()
        {
            foreach (string item in _source)
            {
                //check if it's in the ref dictionary, if yes: return only sub items, if no: return the item
                if (_referenceDic.Keys.Contains(item))
                {
                    foreach (string dicItem in _referenceDic[item])
                        yield return dicItem;
                }
                else
                {
                    yield return item;
                }
            }
        }
  
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
