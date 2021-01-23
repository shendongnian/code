	public class Mammal
	{
		protected string _Name;
	
		public virtual string Name()
		{
				return (this._Name + " - of type " + this.GetType());
		}
		public Mammal(string Name)
		{
			this._Name = Name;
		}
	}
	public class Dog : Mammal
	{
		public Dog(string Name) : base(Name)
		{
		}
	
		public override string Name()
		{
			return (base._Name + "Dog");
		}
	}
	
	static void Main()
	{
		Mammal AnimalA = new Mammal("SubjectA");
		Console.WriteLine("{0}", AnimalA.Name());
	
		Mammal AnimalB = new Dog("SubjectB");
		Console.WriteLine("{0}", AnimalB.Name());
		Console.ReadLine();
	}
