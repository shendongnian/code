    class Program
    {
        static void Main(string[] args)
        {
            Master master = new Master();
            master.Execute();
        }
    }
    class WebService
    {
        public int GetResponse(int i)
        {
            Random rand = new Random();
            i = i + rand.Next();
            Console.WriteLine("Start GetResponse()");
            Thread.Sleep(3000);
            Console.WriteLine("End GetResponse()");
            return i;
        }
        public void SomeMethod(List<int> list)
        {
            //Some work with list        
            Console.WriteLine("List.Count = {0}", list.Count);
        }
    }
    class Master
    {
        private readonly WebService webService = new WebService();
		public void Execute()
		{
			Console.WriteLine("Start main thread..");
			var taskList = new List<Task<int>>();
			for (int i = 0; i < 5; i++)
			{
				Task<int> task = Task.Factory.StartNew(() => webService.GetResponse(1));
				taskList.Add(task);
			}
			Task<List<int>> continueWhenAll =
				Task.Factory.ContinueWhenAll(taskList.ToArray(),
								tasks => tasks.Select(task => task.Result).ToList());
			webService.SomeMethod(continueWhenAll.Result);
			Console.WriteLine("End main thread..");
			Console.ReadLine();
		}
    }
