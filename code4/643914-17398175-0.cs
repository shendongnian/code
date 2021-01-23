    public class SlidingBuffer<T> : IEnumerable<T>
    {
	private readonly Queue<T> _queue;
	public int QueueMax { get; private set; }
	public SlidingBuffer(int maxCount)
	{
		QueueMax = maxCount;
		_queue = new Queue<T>(maxCount);
	}
	public void Add(T item)
	{
		if (_queue.Count >= QueueMax)
		{
			_queue.Dequeue();
		}
		_queue.Enqueue(item);
	}
	public IEnumerator<T> GetEnumerator()
	{
		return _queue.GetEnumerator();
	}
	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}
    }
