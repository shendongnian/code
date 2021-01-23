	System.Globalization.NumberFormatInfo numberFormatInfo = 
		(System.Globalization.NumberFormatInfo) System.Globalization.NumberFormatInfo.CurrentInfo.Clone();
	numberFormatInfo.NaNSymbol = "NaN";
	double num = double.NaN;
	string numString = System.Number.FormatDouble(num, null, numberFormatInfo);
