	public class MyViewModel
	{
		private ICommand _myViewModelCommand;
		public ICommand MyViewModelCommand
		{
			get 
			{
				return _myViewModelCommand
					?? (_myViewModelCommand = new ActionCommand(() => 
					{
						// do something here
					));
			}
		}
	}
