    [JsonObject]
    public class FooCollection : List<int>
    {
    	[DataMember]
        public string Bar { get; set; } = "Bar";
    	public ICollection<int> Items => new _<int>(this);
    }
    public class _<T> : ICollection<T>
    {
    	public _(ICollection<T> collection) => Inner = collection;    
    	public ICollection<T> Inner { get; }    
    	public int Count => this.Inner.Count;    
    	public bool IsReadOnly => this.Inner.IsReadOnly;    
    	public void Add(T item) => this.Inner.Add(item);    
    	public void Clear() => this.Inner.Clear();    
    	public bool Contains(T item) => this.Inner.Contains(item);    
    	public void CopyTo(T[] array, int arrayIndex) => this.Inner.CopyTo(array, arrayIndex);    
    	public IEnumerator<T> GetEnumerator()=> this.Inner.GetEnumerator();
        public bool Remove(T item) => this.Inner.Remove(item);    
    	IEnumerator IEnumerable.GetEnumerator() => this.Inner.GetEnumerator();
    }
