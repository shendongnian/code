		class A
		{
			private A(int i) { }
			public A() { }
			private void Foo() { }
			public void Bar() { }
		}
		class B : A
		{
		}
		var aProperties = typeof(A).GetMembers(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.FlattenHierarchy);
		// you won't see Foo in this line, nor any constructors of A
		var bProperties = typeof(B).GetMembers(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public  | BindingFlags.FlattenHierarchy);
		
