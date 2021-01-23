    using System;
    public static class Test
    {
	public static bool CheckFooTestA(String SearchMe, String[] FindMe)
	{
		//split the string like the human eye does and check the count of Foos 
		//and the position of the Foo or Foos to determine our logic:
		string[] v = SearchMe.Split(FindMe, StringSplitOptions.None);
		
		     //Foo not found, OR foo found once and was at the beginning of the string
		return (v.Length == 0 || v.Length == 1 && v[0] == String.Empty);
	}
	public static bool CheckFooTestB(String SearchMe, String[] FindMe)
	{
		//scan the way computers or non-speed readers do, and look for the first instance of Foo
		int i = SearchMe.IndexOf(FindMe[0]);
		//Foo not found OR 
		//    foo found at the start of the string 
		//    AND the last Foo found is also at the start of the string
		return (i == -1 || i == 0 && SearchMe.LastIndexOf(FindMe[0]) == 0 );
	}
	public static bool CheckFooTestC(String SearchMe, String[] FindMe)
	{
		//Use the logic we distilled from the word problem to make this single check:
		return (SearchMe.LastIndexOf(FindMe[0]) <= 0);
	}
	public static void Main()
	{
		String[] x = new String[]{
			"Foo foo Foo bar",
			"Foo foo foo bar",
			"foo foo Foo bar",
			"foo foo foo bar",
			"asfda asdfa asf" };
			
		var s = new []{"Foo"};
		var i = 0;
		bool f=false;
		long End = DateTime.Now.Ticks;
		long Start = DateTime.Now.Ticks;
		for (; i < 1000; i++) {
			f = CheckFooTestA(x[i%5],s);
		}
		End = DateTime.Now.Ticks;
		Console.WriteLine((End - Start).ToString() + " ticks (Test A)");
		i = 0;
		f = false;
		End = DateTime.Now.Ticks;
		Start = DateTime.Now.Ticks;
		for (; i < 1000; i++) {
			f = CheckFooTestB(x[i%5],s);
		}
		End = DateTime.Now.Ticks;
		Console.WriteLine((End - Start).ToString() + " ticks (Test B)");
		
		i = 0;
		f = false;
		End = DateTime.Now.Ticks;
		Start = DateTime.Now.Ticks;
		for (; i < 1000; i++) {
			f = CheckFooTestC(x[i%5],s);
		}
		End = DateTime.Now.Ticks;
		Console.WriteLine((End - Start).ToString() + " ticks (Test C)");
	}
    }
    Test.Main();
