 		void Main()
		{
			var valuesList = new List<Wrapper<string>>();
			var initialValue = new Wrapper<string>("Alpha");
			valuesList.Add(initialValue);
			
			initialValue.Content = "Bravo";
		
			Console.WriteLine(valuesList[0].Content);
		}
