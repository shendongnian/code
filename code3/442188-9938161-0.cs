	public class Tor<T> where T : new()
	{
	    public Tor(int size)
		{ 
			elements = new T[size];
			for (int i = 0; i < size; i++)
			{
				elements[i] = new T();
			}
		}
		
		private T[] elements;
	
		private int next;
	
		public event EventHandler<EventArgs> queueFull;   
	}
