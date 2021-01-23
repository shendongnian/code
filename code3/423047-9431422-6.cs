	public class Person
	{
		public int SeniorPersonId {get;set;}
		public int JuniorPersonId {get;set;}
		public int SeniorPersonMisId {get;set;}
		public int JuniorPersonMisId {get;set;}
		public int LinkType {get;set;}
		public byte ParentalResponsibility {get;set;}
		public byte? Priority {get;set;}
		public DateTime LastUpdated {get;set;}
		public byte? Deleted {get;set;}
	}
	
	
	void Main()
	{
		var message = new byte[] 
		{
			0x01, 0x00, 0x00, 0x00, // SeniorPersonId
			0xD7, 0x0A, 0x00, 0x00, // JuniorPersonId = 2775
			0x00, 0x00, 0x00, 0x00, // SeniorPersonMisId
			0x00, 0x00, 0x00, 0x00, // JuniorPersonMisId
			0x00, 0x00, 0x00, 0x00, // LinkType
			0x01, // ParentalResponsibility
			0x01, // Priority
			0x80, 0xC3, 0x29, 0xC6, 0x85, 0xBF, 0xCE, 0x08, // LastUpdated
			0x00, // Deleted
		};
		
		var person = new Person();
		int pos = 0;
	
		person.SeniorPersonId = BitConverter.ToInt32(message, pos);
		person.JuniorPersonId = BitConverter.ToInt32(message, pos + 4);
		person.ParentalResponsibility = message[pos + 20];
		person.LastUpdated = DateTime.FromBinary( BitConverter.ToInt64(message, pos + 22) );
	}
