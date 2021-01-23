		/// <summary>
		/// Converts a Roman number string into a Arabic number
		/// </summary>
		/// <param name="romanNumber">the Roman number string</param>
		/// <returns>the Arabic number (0 if the given string is not convertible to a Roman number)</returns>
		public static int ToArabicNumber(string romanNumber)
		{
			string[] replaceRom = { "CM", "CD", "XC", "XL", "IX", "IV" };
			string[] replaceNum = { "DCCCC", "CCCC", "LXXXX", "XXXX", "VIIII", "IIII" };
			string[] roman = { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };
			int[] arabic = { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };
			return Enumerable.Range(0, replaceRom.Length)
				.Aggregate
				(
					romanNumber,
					(agg, cur) => agg.Replace(replaceRom[cur], replaceNum[cur]),
					agg => agg.ToArray()
				)
				.Aggregate
				(
					0,
					(agg, cur) =>
					{
						int idx = Array.IndexOf(roman, cur.ToString());
						return idx < 0 ? 0 : agg + arabic[idx];
					},
					agg => agg
				);
		}
		/// <summary>
		/// Converts a Arabic number into a Roman number string
		/// </summary>
		/// <param name="arabicNumber">the Arabic number</param>
		/// <returns>the Roman number string</returns>
		public static string ToRomanNumber(int arabicNumber)
		{
			string[] roman = { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };
			int[] arabic = { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };
			return Enumerable.Range(0, arabic.Length)
				.Aggregate
				(
					Tuple.Create(arabicNumber, string.Empty),
					(agg, cur) =>
					{
						int remainder = agg.Item1 % arabic[cur];
						string concat = agg.Item2 + string.Concat(Enumerable.Range(0, agg.Item1 / arabic[cur]).Select(num => roman[cur]));
						return Tuple.Create(remainder, concat);
					},
					agg => agg.Item2
				);
		}
