    public static class Tuple
    {
        public static Tuple<T1, T2> Create<T1, T2>(T1 item1, T2 item2)
        {
            return new Tuple<T1, T2>(item1, item2);
        }
        public static Tuple<T1, T2, T3> Create<T1, T2, T3>(T1 item1, T2 item2, T3 item3)
        {
            return new Tuple<T1, T2, T3>(item1, item2, item3);
        }
    }
    public class Tuple<T1, T2> : IEquatable<Tuple<T1, T2>>
    {
    	private readonly T1 _item1;
    	private readonly T2 _item2;
    	public Tuple(T1 item1, T2 item2)
    	{
    		_item1 = item1;
    		_item2 = item2;
    	}
    	public T1 Item1 { get { return _item1; } }
    	public T2 Item2 { get { return _item2; } }
        public bool Equals(Tuple<T1, T2> other)
        {
            return
                ReferenceEquals(this, other)
                ||
                (
                    other != null
                    && (ReferenceEquals(_item1, other._item1) || (_item1 != null && _item1.Equals(other._item1)))
                    && (ReferenceEquals(_item2, other._item2) || (_item2 != null && _item2.Equals(other._item2)))
                );
        }
        public override bool Equals(object obj)
        {
            return Equals(obj as Tuple<T1, T2>);
        }
        public override int GetHashCode()
        {
            int h1 = _item1 == null ? 0 : _item1.GetHashCode();
            int h2 = _item2 == null ? 0 : _item2.GetHashCode();
            return ((h1 << 5) + h1) ^ h2;
        }
    }
    public class Tuple<T1, T2, T3> : IEquatable<Tuple<T1, T2, T3>>
    {
    	private readonly T1 _item1;
    	private readonly T2 _item2;
    	private readonly T3 _item3;
    	public Tuple(T1 item1, T2 item2, T3 item3)
    	{
    		_item1 = item1;
    		_item2 = item2;
    		_item3 = item3;
    	}
    	public T1 Item1 { get { return _item1; } }
    	public T2 Item2 { get { return _item2; } }
    	public T3 Item3 { get { return _item3; } }
        public bool Equals(Tuple<T1, T2, T3> other)
        {
            return
                ReferenceEquals(this, other)
                ||
                (
                    other != null
                    && (ReferenceEquals(_item1, other._item1) || (_item1 != null && _item1.Equals(other._item1)))
                    && (ReferenceEquals(_item2, other._item2) || (_item2 != null && _item2.Equals(other._item2)))
                    && (ReferenceEquals(_item3, other._item3) || (_item3 != null && _item2.Equals(other._item3)))
                );
        }
        public override bool Equals(object obj)
        {
            return Equals(obj as Tuple<T1, T2, T3>);
        }
        public override int GetHashCode()
        {
            int h1 = _item1 == null ? 0 : _item1.GetHashCode();
            int h2 = _item2 == null ? 0 : _item2.GetHashCode();
            int h3 = _item3 == null ? 0 : _item3.GetHashCode();
            int h = ((h1 << 5) + h1) ^ h2;
            return ((h << 5) + h) ^ h3;
        }
    }
