    public enum TestEnum
	{
		None,
		A,
		B,
	};
	void Main()
	{
		var testValues = new List<object>();
		testValues.AddRange(Enumerable.Range(-2, 6).Select(i => (object)i));
		testValues.AddRange(new List<string>() { String.Empty, "A", "B", "C", null });
		foreach (var testValue in testValues)
		{
			Console.WriteLine($"Testing value {testValue ?? String.Empty}:");
			TestEnum output;
			var enumValues = Enum.GetNames(typeof(TestEnum)).ToList();
			try
			{
				if (TestEnum.TryParse(testValue.ToString(), out output) && enumValues.Contains(output.ToString()))
				{
					Console.WriteLine($"Succeeded with TryParse on {testValue} to {output}");
				}
				else
				{
					Console.WriteLine($"Failed to TryParse on {testValue}");
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Test harness caught an exception: {ex.ToString()}");
			}
			
			var toEnumOutput = (testValue ?? String.Empty).ToString().Parse<TestEnum>();
			Console.WriteLine($"Parse<TEnum> returned {toEnumOutput}");
			Console.WriteLine();
			Console.WriteLine();
		}
	}
	public static class EnumExtensions
	{
		public static TEnum Parse<TEnum>(this string value) where TEnum : struct
		{
			TEnum output = default(TEnum);
			var enumValues = Enum.GetNames(typeof(TEnum)).ToList();
			if (Enum.TryParse<TEnum>(value, true, out output))
				if (Enum.IsDefined(typeof(TEnum), value) || value.ToString().Contains(",") || enumValues.Contains(output.ToString()))
				{
					Console.WriteLine($"Converted '{value}' to {output}.");
					return output;
				}
				else
				{
					Console.WriteLine($"{value} is not an underlying value of the enumeration.");
				}
			else
			{
				Console.WriteLine($"{value} is not a member of the enumeration.");
			}
			return default(TEnum);
		}
	}
