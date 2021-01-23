		class A:C
		{
			public C GetC()
			{
				return new C();
			}
		}
		
		class C
		{
		    protected C()
			{
			}
		}
