	class Cat : Mammal
	{
		// other specific members
		public override bool Is(MammalTypes mammalType)
		{
			return mammalType == MammalTypes.Cat;
		}
	}
	class Dog : Mammal
	{
		// other specific members
		public override bool Is(MammalTypes mammalType)
		{
			return mammalType == MammalTypes.Dog;
		}
	}
