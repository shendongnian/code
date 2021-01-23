	class A<T> where T : A<T>
	{
		public virtual void GetType()
		{
			Test.WhatType<T>( (T) this );
		}
	}
	class B : A<B> { }
