			public static ConsoleKey ReadKeySingle(bool intercept = false)
			{
				ConsoleKey key = Console.ReadKey(intercept).Key;
				while (Console.KeyAvailable) {
					Console.ReadKey(true);
					key = ConsoleKey.Clear;
				}
				return key;
			}
