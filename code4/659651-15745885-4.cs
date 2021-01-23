	public class Test
	{
		private readonly ImmutableClass immutableMember;
		protected ImmutableClass ImmutableMember { get { return immutableMember; } }
		public Test(ImmutableClass immutableMember)
		{
			this.immutableMember = immutableMember;
		}
	}
