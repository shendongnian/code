       public class ViewModel
	{
		public ViewModel()
		{
			_persons = new ObservableCollection<Person>();
			_persons.Add(new Person() { Name = "Paul", Checked = false });
			_persons.Add(new Person() { Name = "Brian", Checked = true });
		}
		private ObservableCollection<Person> _persons;
		public ObservableCollection<Person> Persons
		{
			get { return _persons; }
		}
	}
	public class Person
	{
		public String Name { get; set; }
		public Boolean Checked { get; set; }
	}
