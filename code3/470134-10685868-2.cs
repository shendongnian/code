    private T getEnumStringEnumType<T>() where T : struct, IConvertible
		{
			string userInputString = string.Empty;
			T resultInputType = default(T);
			bool enumParseResult = false;
			while (!enumParseResult)
			{
				userInputString = System.Console.ReadLine();
				enumParseResult = Enum.TryParse<T>(userInputString, out resultInputType);
			}
			return resultInputType;
		}
