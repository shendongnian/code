	interface IPerson
	{	
		string Name { get; }
	}
	
	interface IDoctor: IPerson
	{
		int DoctorSpecificProperty { get; }
	}
	
	interface IPatient
	{
		int PatientSpecificProperty { get; }
	}
	
