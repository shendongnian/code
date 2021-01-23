		private void extractDate(string date, string rDate, out DateTime regDate, out DateTime dob)
		{
			Parallel.Invoke(
				() =>
				{
					if (date == "")     // Date of birth is not given;
					{
						regDate = getStandardDate(rDate);   // MM/DD/YYYY
						dob = regDate.AddYears(-18);
					}
					else
					{
						dob = getStandardDate(date);
					}
				},
			() =>
			{
				if (rDate == "")
				{
					dob = getStandardDate(date);
					regDate = dob.AddYears(18);
				}
				else
				{
					regDate = getStandardDate(rDate);
				}
			});
		}
		private DateTime getStandardDate(string date)
		{
			IFormatProvider culture = new System.Globalization.CultureInfo("en-gb", true);
			DateTime dt;
			if (karachiDateFormat)
			{
				if (!DateTime.TryParse(date, out dt))
					dt = DateTime.Now.Date;
			}
			else
			{
				if (!DateTime.TryParse(date, culture, out dt))
					dt = DateTime.Now.Date;
			}
		}
