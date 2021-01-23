   	class WrappedThing<T>
	{
		public WrappedThing(T thing)
		{
			Thing = thing;
		}
		public T Thing { get; private set; }
	}
