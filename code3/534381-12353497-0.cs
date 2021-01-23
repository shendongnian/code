foreach(var person in SQLiteDB.persons)
{
    Person thenewperson = new Person();
    foreach (var prop in person.GetType().GetProperties())
    {
		var newPersonProp = thenewperson.GetType().GetProperties()
												  .Where(p => p.Name.ToLower() == prop.Name.ToLower())
												  .FirstOrDefault();
												  
		if (newPersonProp != null)
		{
			newPersonProp.SetValue(thenewperson, prop.GetValue(person, null), null);
		}
    }
    SQlserverDB.Persons.AddorUpdate(thenewperson) // Not totaly correct but you get the point.
} 
