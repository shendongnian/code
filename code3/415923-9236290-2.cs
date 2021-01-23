    internal class MyClass
    	{
    		private Queue<Func<object[], bool>> m_taskQueue;
    
    		protected MyClass()
    		{
    			m_taskQueue = new Queue<Func<object[], bool>>();
    		}
    
    
    
    		public void EnqueueTask(Func<object[], bool> task)
    		{
    			m_taskQueue.Enqueue(task);
    		}
    
    		public virtual bool Save()
    		{
    			object[] arguments = null; // assign arguments to something
    			// save by processing work queue
    			while (m_taskQueue.Count > 0)
    			{
    				var task = m_taskQueue.Dequeue();
    				var workItemResult = task(arguments);
    
    				if (!workItemResult)
    				{
    					// give up on a failure
    					m_taskQueue.Clear();
    					return false;
    				}
    			}
    			return true;
    		}
    	}
