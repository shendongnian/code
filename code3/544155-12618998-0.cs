		public static void outputDetail<T>(DateTime previousTime, ref T[] array, System.IO.StreamWriter streamWriter)  //the parameter in here is not necessary, but want to maintain a similiarity in the TimeOfDay class
		{
			string outputString = previousTime.ToString("yyyy/MM/dd");
			Boolean bypass = true;
			for (int i = 1; i < array.Length - 1; i++)
			{
				if (!Object.Equals(array[i], default(T)))
				{
					outputString = outputString + "," + array[i].ToString();
					bypass = false;
				}
				else
				{
					outputString = outputString + ",";
				}
			}
			if (bypass == false)
				streamWriter.WriteLine(outputString);
			Array.Clear(array, 0, array.Length);
		}
