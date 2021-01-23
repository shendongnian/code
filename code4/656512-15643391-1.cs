	public class SortedContentViewModel
	{
		public ObservableCollection<GameViewModel> GameList { get; set; }
		public SortedContentViewModel()
		{
			GameList = new ObservableCollection<GameViewModel>()
			{
				new GameViewModel() {Name="Brink", ImagePath = @"Resources/brink.png" },
				new GameViewModel() {Name="Bulletstorm", ImagePath = @"Resources/bulletstorm.png" }
			};
		}
	}
