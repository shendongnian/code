		void Main()
		{
			List<IMachines> mList = new List<IMachines>();
			
			mList.Add(new AC());
			mList.Add(new Generator());
			mList.Add(new AC());
			mList.Add(new Generator());
			mList.Add(new Generator());
			mList.Add(new Generator());
			
			var differentIMachines = mList.GroupBy(t=>t.GetType());
			foreach(var grouping in differentIMachines)
			{
					Console.WriteLine("Type - {0}, Count - {1}", grouping.Key, grouping.Count());
					
					foreach(var item in grouping)
					{
					//iterate each item for particular type here
					}
			}
				
		}
		
		interface IMachines {	}
		
		class AC : IMachines {}
		
		class Generator : IMachines {}
