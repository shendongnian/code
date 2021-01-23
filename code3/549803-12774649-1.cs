	EmptyRowProvider.RegisterType(() => new ContactList() { Email = String.Empty, Name = String.Empty });
	
	
	var emptyRow = EmptyRowProvider.GetEmptyRow<ContactList>();
	
	Console.WriteLine(emptyRow.Count); //1
	Console.WriteLine(emptyRow[0].Email == String.Empty); //true
	Console.WriteLine(emptyRow[0].Name == String.Empty); //true
