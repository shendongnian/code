	class Person : IPerson
	{
		IList<IPerson> parents;
		public Person(IList<IPerson> parents)
		{
			this.parents = parents;
		}
		public IList<IPerson> GetAllParents()
		{
			return parents;
		}
	}
