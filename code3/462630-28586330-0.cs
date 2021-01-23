    public class Trie<TItem> where TItem : class
    {
        #region Constructors
        public Trie(
            IEnumerable<TItem> items,
            Func<TItem, string> keySelector,
            IComparer<TItem> comparer)
        {
            this.KeySelector = keySelector;
            this.Comparer = comparer;
            this.Items = (from item in items
                          from i in Enumerable.Range(1, this.KeySelector(item).Length)
                          let key = this.KeySelector(item).Substring(0, i)
                          group item by key)
                         .ToDictionary( group => group.Key, group => group.ToList());
        }
        #endregion
        #region Properties
        protected Dictionary<string, List<TItem>> Items { get; set; }
        protected Func<TItem, string> KeySelector { get; set; }
        protected IComparer<TItem> Comparer { get; set; }
        #endregion
        #region Methods
        public void Add(TItem item)
        {
            var keys = (from i in Enumerable.Range(1, this.KeySelector(item).Length)
                        let key = this.KeySelector(item).Substring(0, i)
                        select key).ToList();
            keys.ForEach(key =>
            {
                if (!this.Items.ContainsKey(key))
                {
                    this.Items.Add(key, new List<TItem> { item });
                }
                else if (this.Items[key].All(x => this.Comparer.Compare(x, item) != 0))
                {
                    this.Items[key].Add(item);
                }
            });
        }
        public void Remove(TItem item)
        {
            this.Items.Keys.ToList().ForEach(key =>
            {
                if (this.Items[key].Any(x => this.Comparer.Compare(x, item) == 0))
                {
                    this.Items[key].RemoveAll(x => this.Comparer.Compare(x, item) == 0);
                    if (this.Items[key].Count == 0)
                    {
                        this.Items.Remove(key);
                    }
                }
            });
        }
        public List<TItem> Retrieve(string prefix)
        {
            return  this.Items.ContainsKey(prefix)
                ? this.Items[prefix]
                : new List<TItem>();
        }
        #endregion
    }
