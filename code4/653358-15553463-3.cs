	public class PersonViewModel : ViewModelBase
	{
		private Person person { get; set; }
		public Guid Id { get { return person.Id; } }
		public String FirstName
		{
			get { return person.FirstName; }
			set
			{
				if (person.FirstName != value)
				{
					person.FirstName = value;
					RaisePropertyChanged("FirstName");
				}
			}
		}
		public string MiddleName
		{
			get { return person.MiddleName; }
			set
			{
				if (person.MiddleName != value)
				{
					person.MiddleName = value;
					RaisePropertyChanged("MiddleName");
				}
			}
		}
		public string LastName
		{
			get { return person.LastName; }
			set
			{
				if (person.LastName != value)
				{
					person.LastName = value;
					RaisePropertyChanged("LastName");
				}
			}
		}
		public string FullName { get { return LastName + ", " + FirstName + " " + MiddleName; } }
		public PersonViewModel()
		{
			person = new Person();
		}
		
		public PersonViewModel(Person inPerson)
		{
			person = inPerson;
		}
	}
