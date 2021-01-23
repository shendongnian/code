    class BlockingQueue<T>
	{
		readonly Queue<T> q = new Queue<T>();
		public void Enqueue(T item)
		{
			lock (q)
			{
				while (false) // condition predicate(s) for producer; can be omitted in this particular case
				{
					System.Threading.Monitor.Wait(q);
				}
				// critical section
				q.Enqueue(item);
			}
			// generally better to signal outside the lock scope
			System.Threading.Monitor.Pulse(q);
		}
		public T Dequeue()
		{
			T t;
			lock (q)
			{
				while (q.Count == 0) // condition predicate(s) for consumer
				{
					System.Threading.Monitor.Wait(q);
				}
				// critical section
				t = q.Dequeue();
			}
            // this can be omitted in this particular case; but not if there's waiting condition for the producer as the producer needs to be woken up; and here's the problem caused by missing condition variable by C# monitor: all threads stay on the same waiting queue of the shared resource/lock.
			System.Threading.Monitor.Pulse(q);
			return t;
		}
	}
