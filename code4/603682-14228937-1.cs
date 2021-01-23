	class MyViewModel : INavigatable
	{
		public event NavigateEventHandler Navigate;
		
		MyViewModel()
		{
			NavigateCommand = new DelegateCommand(() => 
			{
				RaiseNavigateEvent();
			}) ;
		}
		
		void RaiseNavigateEvent()
		{
			var temp = Navigate;
			if (temp != null)
			{
				temp(new NavigateEventArgs{Target = Link});
			}
		}
	
		public string Link {get;set;} // this should be bound to Button.Content (preferably in XAML)
		public ICommand NavigateCommand{ get;set;}
	}
