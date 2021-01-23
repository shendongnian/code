	public static void Main()
	{
		var people = new PersonRepo()
		Person Luke = new Person();
		Luke.Update("Luke", 15);
		people.Upsert(Luke.ID,Luke);
		Person Daniel = new Person();
		Daniel.Update("Daniel", 14, "Jones");
		people.Upsert(Daniel.ID,Daniel);
		Person Aimee = new Person();
		Aimee.Update("Aimee", 18, "Jones");
		people.Upsert(Daniel.ID,Daniel);
		Person Will = new Person();
		Will.Update("William", 22, "Rae");
		people.Upsert(Daniel.ID,Daniel);
		
		// To get the person by id you can do
		int id = 3;
		var person = people.Get(id)
		Console.WriteLine(person.ToString())
	}	
