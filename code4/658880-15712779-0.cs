	using System.Diagnostics.Contracts;
	void MyMethod(string someParameter)
	{
		Contract.Requires<ArgumentNullException>(someParameter != null);
		
		// ...
	}
