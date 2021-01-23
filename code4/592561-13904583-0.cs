	class A_list : IEnumerable<A>
	{
                // ... your other code
		
		public IEnumerator<A> GetEnumerator()
		{
			return ((IEnumerable<A>)list).GetEnumerator();
		}
		
		
		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
			return list.GetEnumerator();
		}
	}
