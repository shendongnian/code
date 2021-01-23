	public class PersonRepo
	{
		static Dictionary<int, Person> people = new Dictionary<int, Person>();
		public void Upsert(Person P)
		{
			if (people.ContainsKey(P.ID))
				people[P.ID] = P;
			else
				people.Add(P.ID, P);
		}
		public Person Get(int ID)
		{
			if (!people.ContainsKey(ID))
				return null;
			return people[ID];
		}
	}
	
