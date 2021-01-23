	public class Base
	{
		// put anything here that doesn't rely on the type of T
		// if you need things here that would rely on T, use EntityObject and have 
		// your subclasses provide new implementations using the more specific type
	}
    public class Base<T> : Base where T : EntityObject
    {
        protected Helper<T> helper;
    }
    public class Child : Base<MyEntity>
    {
        public Child()
        {
            helper = new Helper<MyEntity>();
        }
    }
	public class User
	{
		private Base myBase;
		public User(TypeEnum t)
		{
			if(t == TypeEnum.MyEntity) myBase = new Child();
			...
