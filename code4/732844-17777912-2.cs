	public interface IBotCommand
	{
		string Name { get; }
		bool IsAdmin { get; }
		void Process(string[] args);
		string HelpText { get; }
	}
	
	public class MyCommand : IBotCommand
	{
		string Name 
		{
			get
			{
				return "NameOfTheCommand";
			}
		}
	
		bool IsAdmin 
		{ 
			get 
			{ 
				return false; 
			} 
		}
		
		void Process(string[] args)
		{
		    // bla bla, im processing stuff
		}
		
		string HelpText 
		{ 
			get 
			{ 
				return "This is the help text"; 
			} 
		}
	}
