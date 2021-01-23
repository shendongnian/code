	public interface IDoStuff
	{
		string AProperty { get; set; }
		bool SomeMethod(int anArgument);
	}
	public class TheImplementation : IDoStuff
	{
		public string AProperty { get; set; }
		public bool SomeMethod(int anArgument)
		{
			return false;
		}
        public void AnotherMethod()
        {
            this.AProperty = string.Empty
        }
	}
