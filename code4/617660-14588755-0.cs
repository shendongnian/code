    public class Program
	{
		private static List<KeyValuePair<string, string>> questions = new List<KeyValuePair<string, string>>
		{
			new KeyValuePair<string,string>("-What is the capital of France", "Paris"),
			new KeyValuePair<string,string>("-What is the capital of Spain", "Madrid"),
			new KeyValuePair<string,string>("-What is the captial of Russia", "Moscow"),
			new KeyValuePair<string,string>("-What is the capital of Ukraine", "Kiev"),
			new KeyValuePair<string,string>("-What is the capital of Egypt", "Cairo"),
		};
		
		static void Main()
		{
			var questions = ShuffleQuestions();
			
			foreach(var question in questions)
			{
				bool done = false;
				while(!done)
				{
					Console.WriteLine(question.Key);
					string a = Console.ReadLine();
					
					if (a == question.Value)
					{
						Console.WriteLine("It's True \n*Next Question is:");
						done = true;
					}
					else
						Console.WriteLine("It's False \n*Please Try Again.");
				}
			}
			
			Console.ReadLine();
		}
		
		private IEnumerable<KeyValuePair<string, string>> ShuffleQuestions()
		{
			var list = questions;
			var random = new Random();  
			int items = list.Count;  
			while (items > 1) {  
				items--;  
				int nextItem = random.Next(items + 1);  
				var value = list[nextItem];  
				list[nextItem] = list[items];  
				list[items] = value;  
			}
			
			return list;
		}
	}
