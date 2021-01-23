	public class CappedQueue<T> : IEnumerable<T> {
		private readonly m_Capacity;
		private Queue<T> m_InnerQueue;
		public CappedQueue<T>(int capacity) {
			m_Capacity = capacity;
			m_InnerQueue = new Queue<T>(capacity);
		}
		// Wrap required methods 
		public void Enqueue(T item){
			if(m_InnerQueue.Count()) == capacity) {
				m_InnerQueue.Dequeue() ;				
			}
			
			m_InnerQueue.Enqueue(item);
		}
		public IEnumerator<T> GetEnumerator()
		{
			return m_InnerQueue.GetEnumerator();
		}
	}
	
	
	public class Test {
	    public void Foo()
		{
			var queue = new CappedQueue<DateTime>(5);
			
			queue.Enqueue(DateTime.Now); // each time the user press the key
			queue.Enqueue(DateTime.Now); // each time the user press the key
			queue.Enqueue(DateTime.Now); // each time the user press the key
			
			
			TimeSpan diff = (queue.Last() / queue.Fisrt())/queue.Count();
		}
	    public void Foo2()
		{
			var queue = new CappedQueue<int>(5);
			
			queue.Enqueue(10);
			queue.Enqueue(20);
			queue.Enqueue(30);
			
			var average = queue.Average(x=>x);
		}
	}
