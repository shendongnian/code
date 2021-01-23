		static string find(int val)
		{
			int[] keys = {30,40,50};
			string[] messages = {"Below 30","Below 40","Below 50"};
			int idx = Array.BinarySearch(keys,val);
			if(idx < 0)idx = ~idx;
			return idx < 3 ? messages[idx] : "Off the chart!";
		}
		public static void Main (string[] args)
		{
			Console.WriteLine (find(28));
			Console.WriteLine (find(50));
			Console.WriteLine (find(100));
		}
