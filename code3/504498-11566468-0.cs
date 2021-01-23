		static Random r = new Random();
		public static string RandomDecimal(int maxValue, int precision)
		{
			decimal result = r.Next(maxValue);
	
			if (maxValue != 0)
			{
				int i = 1;
		
				decimal digit = 0;
		
				while (i <= precision)
				{
					digit = r.Next(10);
					digit = (digit / (Convert.ToDecimal(Math.Pow(10, i))));
					result = result + digit;
					i++;
				}
			}
			var sb = new StringBuilder("0.");
			sb.Append('0', precision);
			return result.ToString(sb.ToString());
		}
