	public class Dispatcher : MonoBehaviour
	{       
		private static readonly Queue<Action> tasks = new Queue<Action>();
		public static Dispatcher Instance = null;
		static Dispatcher()
		{
			Instance = new Dispatcher();
		}
		private Dispatcher()
		{
		}
		public void InvokeLater(Action task)
		{
			lock (tasks)
			{
				tasks.Enqueue(task);
			}
		}
		void FixedUpdate()
		{
			while (tasks.Count > 0)
			{
				Action task = null;
			
				lock (tasks)
				{
					if (tasks.Count > 0)
					{
						task = tasks.Dequeue();
					}
				}
				
				task();
			}
		}
	}
