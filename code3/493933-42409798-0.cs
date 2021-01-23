	public static T Denqueue<T>(this Queue<T> queue)
	{
		var item = queue.Dequeue();
		queue.Enqueue(item);
		return item;
	}
