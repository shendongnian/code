	namespace ConsoleApplication1
	{
		using System;
		class Program
		{
			const int MapRows = 5;
			const int MapColumns = 5;
			static void Main(string[] args)
			{
				// Create map and the raw data (from file)
				var map = new int[MapRows, MapColumns];
				string rawMapData = "1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25";
				string[] splitData = rawMapData.Split(',');
				int index = 0;
				// Loop through data
				for (int row = 0; row < MapRows; row++)
				{
					for (int column = 0; column < MapColumns; column++)
					{
						// Store in map and show some debug
						map[row, column] = int.Parse(splitData[index++]);
						Console.WriteLine(string.Format("{0},{1} = {2}", row, column, map[row, column]));
					}
				}
				// Wait for user to read
				Console.ReadKey();
			}
		}
	}
