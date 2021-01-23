    public class Patient
    {
        [PrimaryKey]
        public int    PersonID;
        public string Diagnosis;
        //more class definition
    }
	public class Person
	{
        //some class definition
		[Identity, PrimaryKey]
		//[SequenceName("PostgreSQL", "Seq")]
		[SequenceName("Firebird",   "PersonID")]
		[MapField("PersonID")] public int    ID;
		                       public string FirstName { get; set; }
		                       public string LastName;
		[Nullable]             public string MiddleName;
		                       public Gender Gender;
		[MapIgnore]            public string Name { get { return FirstName + " " + LastName; }}
		[Association(ThisKey = "ID", OtherKey = "PersonID", CanBeNull = true)]
		public Patient Patient;
        //more class definition
    }
