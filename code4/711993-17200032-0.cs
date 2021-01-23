    public class Dispatcher : MonoBehaviour
	{       
		private static readonly BlockingCollection<Action> tasks = new BlockingCollection<Action>();
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
			tasks.Add(task);
		}
		void FixedUpdate()
		{
			if (tasks.Count > 0)
			{
				foreach (Action task in tasks.GetConsumingEnumerable())
				{
					task();
				}
			}
		}
	}
	...
	NetworkController networkControllerInstance;
	void recvData()
	{
		m_UDPClient = new UdpClient(m_Port);
		while (true)
		{
			try
			{
				IPEndPoint anyIP = new IPEndPoint(IPAddress.Any, 0);
				byte[] data = (m_UDPClient.Receive(ref anyIP));  
				Dispatcher.Instance.InvokeLater(() => networkControllerInstance.OnNewData(data));
			}
			catch (Exception err)
			{
				print(err.ToString());
			}
		}
	}
