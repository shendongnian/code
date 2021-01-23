	public class MainViewModel : ViewModelBase
	{
		public List<PersonViewModel> People { get; set; }
		public MainViewModel()
		{
			// Get the people list from your data provider (in this case returns IEnumerable<Person>)
			var peopleList = DataProvider.GetPeople();
			// Wrap each person in a PersonViewModel to make them more UI friendly
			People = peopleList.Select(p => new PersonViewModel(p)).ToList();
		}
	}
