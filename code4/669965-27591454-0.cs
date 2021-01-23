	string FormatNumber<T>(T number, int maxDecimals = 4) {
		return Regex.Replace(String.Format("{0:n" + maxDecimals + "}", number),
		                     @"[" + System.Globalization.NumberFormatInfo.CurrentInfo.NumberDecimalSeparator + "]?0+$", "");
	}	
	
	void Main(){
		foreach (var test in new[] { 123, 1234, 1234.56, 123456.789, 1234.56789123 } )
			Console.WriteLine(test + " = " + FormatNumber(test));
	}
