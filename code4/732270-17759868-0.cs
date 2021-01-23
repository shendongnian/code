	var people = new Dictionary<int,Person>()
	Person Luke = new Person();
	Luke.Update("Luke", 15);
	people.add(Luke.ID,Luke);
	Person Daniel = new Person();
	Daniel.Update("Daniel", 14, "Jones");
	people.add(Daniel.ID,Daniel);
	Person Aimee = new Person();
	Aimee.Update("Aimee", 18, "Jones");
	people.add(Daniel.ID,Daniel);
	Person Will = new Person();
	Will.Update("William", 22, "Rae");
	people.add(Daniel.ID,Daniel);
        
	for(int i=0;i<5;i++)// now try to get the person by ID
	{
		if(people.ContainsKey(i))
		{
			Console.WriteLine(people[i].ToString())
		}
	}
