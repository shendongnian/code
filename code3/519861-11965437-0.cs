	void Main()
	{
		A a = new A();
		a.f += () => Task.Factory.StartNew(Work1);
		a.f += () => Task.Factory.StartNew(Work2);
		a.Start();
	}
