    public class MyViewModel
	{
		public MyViewModel()
		{
			MyViewModelCommand = new ActionCommand(DoSomething);
		}
		public ICommand MyViewModelCommand { get; private set; }
		private void DoSomething()
		{
			// no, seriously, do something here
		}
	}
