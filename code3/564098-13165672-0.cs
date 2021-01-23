	public class A
	{
		public ReactiveCommand SomeCommand { get; protected set; }
		public A()
		{
			SomeCommand = new ReactiveCommand(this.WhenAny(x => x.SomeProp, ...));
		}
	}
	public class B : A
	{
		public A()
		{
			SomeCommand = new ReactiveCommand(this.WhenAny(x => x.SomeOtherProp, ...));
		}
	}
