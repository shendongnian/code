		public static void readDataInt<T>(string value, ref T[][] data, ref DateTime[] timeframe, ref DateTime[] date)
		{
			string inputFile = "D:\\temp.csv";
			string[][] temp = null;
			if (File.Exists(inputFile))
			{
				string[] proRataVolumeFile = File.ReadAllLines(inputFile);
				temp = new string[proRataVolumeFile.Length][];
				for (int i = 0; i < proRataVolumeFile.Length; i++)
				{
					temp[i] = proRataVolumeFile[i].Split(',');
				}
			}
			date = new DateTime[temp.Length - 1];
			timeframe = new DateTime[temp[0].Length - 1];
			data = new T[temp.Length - 1][];
			for (int i = 1; i < temp.Length; i++)
			{
				data[i - 1] = new T[temp[i].Length - 1];
				for (int j = 1; j < temp[i].Length; j++)
				{
					if (temp[i][j].Length > 0)
						data[i - 1][j - 1] = (T)((IConvertible)temp[i][j]).ToType(typeof(T),
							System.Globalization.CultureInfo.InvariantCulture);
				}
			}
			for (int i = 1; i < temp.Length; i++)
			{
				date[i - 1] = DateTime.Parse(temp[i][0]);
			}
			for (int j = 1; j < temp[0].Length; j++)
			{
				timeframe[j - 1] = DateTime.Parse(temp[0][j]);
			}
		}
