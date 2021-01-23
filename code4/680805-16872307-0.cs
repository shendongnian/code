			string dateString = mo.Properties["LastUse"].Value.ToString();
			if (dateString.Substring(4, 2) == "00" || dateString.Substring(6, 2) == "00")
			{
				d = DateTime.ParseExact("19800101", "yyyyMMdd", null);
			}
			else
			{
				d = ManagementDateTimeConverter.ToDateTime(dateString);
			}
