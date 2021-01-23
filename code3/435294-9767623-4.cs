	sealed class ProductProcessor
	{
		public void Process(Product product)
		{
			lock (_queues)
			{
				if (_queues.ContainsKey(product.Type))
					_queues[product.Type].Enqueue(product);
				else
				{
					ConcurrentQueue<Product> queue = new ConcurrentQueue<Product>();
					queue.Enqueue(product);
					_queues.Add(product.Type, queue);
					WaitCallback action = delegate(object state)
					{
						Product productToProcess;
						while (queue.TryDequeue(out productToProcess))
						{
							ProcessProduct(productToProcess);
						}
						lock (_queues) _queues.Remove(product.Type);
					};
					ThreadPool.QueueUserWorkItem(action);
				}
			}
		}
		private Dictionary<string, ConcurrentQueue<Product>> _queues
			= new Dictionary<string, ConcurrentQueue<Product>>();
		private void ProcessProduct(Product product)
		{
		}
	}
