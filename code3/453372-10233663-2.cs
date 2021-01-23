		public static IEnumerable<string> SplitEvery(this string str, int chunkSize, bool splitAtSpaces)
		{
			if (splitAtSpaces)
			{
				return SplitEvery_AtSpace(str, chunkSize);
			}
			else
			{
				return SplitEvery_IgnoreSpace(str, chunkSize);
			}
		}
		public static IEnumerable<string> SplitEvery_AtSpace(string str, int chunkSize)
		{
			int lastStartPoint = 0,
				nextStartPoint = chunkSize;
			List<string> output = new List<string>();
			for (int i = 0; i < str.Length && nextStartPoint < str.Length; i++)
			{
				while (nextStartPoint > lastStartPoint + 1 && str[nextStartPoint - 1] != ' ')
				{
					nextStartPoint--;
				}
				if (nextStartPoint == lastStartPoint)	//If no space in line break
				{
					output.Add(str.Substring(lastStartPoint, chunkSize));
					nextStartPoint += chunkSize;
				}
				else
				{
					output.Add(str.Substring(lastStartPoint, nextStartPoint - lastStartPoint - 1));	//-1 skips space
				}
				//Prep for next loop
				lastStartPoint = nextStartPoint;
				nextStartPoint += chunkSize;
			}
			if (lastStartPoint < str.Length) { output.Add(str.Substring(lastStartPoint)); }	//Add leftover
			return output;	//May want to convert to array if it will be accessed often.
		}
		public static IEnumerable<string> SplitEvery_IgnoreSpace(string str, int chunkSize)
		{
			int lastInserted = 0;
			List<string> output = new List<string>();
			for (int i = 0; i < str.Length && (lastInserted + chunkSize) < str.Length; i++)
			{
				output.Add(str.Substring(lastInserted, chunkSize));
				//Prep for next loop
				lastInserted += chunkSize;
			}
			if (lastInserted < str.Length) { output.Add(str.Substring(lastInserted)); }	//Add leftover
			return output;	//May want to convert to array if it will be accessed often.
		} 
