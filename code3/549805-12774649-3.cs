	EmptyRowProvider.RegisterType(() => new ContactList(String.Empty, String.Empty, true));
	EmptyRowProvider.RegisterType(() => new Person("John", "Doe"));
	EmptyRowProvider.RegisterType(() => UserProvider.SetupAnonymousUser("myusername", "mypassword", LoginType.Anonymous));
	ContactList emptyContactList = EmptyRowProvider.GetEmptyRow<ContactList>();
	Person emptyPerson = EmptyRowProvider.GetEmptyRow<Person>();
	User emptyUser = EmptyRowProvider.GetEmptyRow<User>();
