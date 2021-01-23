		/// <summary>
		/// Legal values: Case insensitive strings TRUE/FALSE, T/F, YES/NO, Y/N, numbers (0 => false, non-zero => true)
		/// Similar to "bool.TryParse(string text, out bool)" except that it handles values other than 'true'/'false' and handles numbers like C/C++
		/// </summary>
		public static bool TryParseBool(object inVal, out bool retVal)
		{
			// There are a couple of built-in ways to convert values to boolean, but unfortunately they skip things like YES/NO, 1/0, T/F
			//bool.TryParse(string, out bool retVal) (.NET 4.0 Only); Convert.ToBoolean(object) (requires try/catch)
			inVal = (inVal ?? "").ToString().Trim().ToUpper();
			switch ((string)inVal)
			{
				case "TRUE":
				case "T":
				case "YES":
				case "Y":
					retVal = true;
					return true;
				case "FALSE":
				case "F":
				case "NO":
				case "N":
					retVal = false;
					return true;
				default:
					// If value can be parsed as a number, 0==false, non-zero==true (old C/C++ usage)
					double number;
					if (double.TryParse((string)inVal, out number))
					{
						retVal = (number != 0);
						return true;
					}
					// If not a valid value for conversion, return false (not parsed)
					retVal = false;
					return false;
			}
		}
