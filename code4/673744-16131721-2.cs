    public class List<T> : IList<T>, ICollection<T>, IList, ICollection, IReadOnlyList<T>, IReadOnlyCollection<T>, IEnumerable<T>, IEnumerable
    {
		private T[] _items; //4 bytes for x86, 8 for x64
		private int _size; //4 bytes
		private int _version; //4 bytes
		[NonSerialized]
		private object _syncRoot; //4 bytes for x86, 8 for x64
		private static readonly T[] _emptyArray; //one per type
		private const int _defaultCapacity = 4; //one per type
        ...
    }
