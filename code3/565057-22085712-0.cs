    using System;
    class ViewState
	{
		public string this[string propertyName]
		{
			get { return propertyName; }
			set { }
		}
	};
	class View
	{
		ViewState mState = new ViewState();
		static string GetCallerName(
			[System.Runtime.CompilerServices.CallerMemberName] string memberName = "")
		{
			return memberName;
		}
		public string MyProperty
		{
			get { return (string)mState[GetCallerName()]; }
			set { mState[GetCallerName()] = value; }
		}
	};
	class Program
	{
		static void Main(string[] args)
		{
			var view = new View();
			Console.WriteLine(view.MyProperty);
			Console.ReadKey();
		}
	};
