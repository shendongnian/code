	public void methodA(BaseClassA myVar)
	{
		if (myVar is ClassA)
		{
			//Its of type ClassA so you can do whatever you want with it knowing it is a ClassA.
		}
		else if (myVar is ClassB)
		{
			//Its of type ClassB so you can do whatever you want with it knowing it is a ClassB.
		}
		else
		{
			//Its not either.
		}
	}
