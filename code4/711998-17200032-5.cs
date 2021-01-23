	void FixedUpdate()
	{
		if (tasks.Count != 0)
		{
			Action task = null;
		
			lock (tasks)
			{
				if (tasks.Count != 0)
				{
					task = tasks.Dequeue();
				}
			}
			
			task();
		}
	}
