	public class Reader
	{
		private static int count= 0;
		
		public void ReadMemory()
		{
			//read memory
			
			// Sleep every 501 iterations
			if (Reader.count++ == 500)
			{
				Thread.Sleep(1);
				Reader.count  = 0;
			}
		}
	}
	
