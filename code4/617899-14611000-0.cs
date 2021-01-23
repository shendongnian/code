    	public override object Get(IDataReader rs, int index)
		{
			try
			{
				DateTime dbValue = Convert.ToDateTime(rs[index]);
				return new DateTime(dbValue.Year, dbValue.Month, dbValue.Day, dbValue.Hour, dbValue.Minute, dbValue.Second);
			}
			catch (Exception ex)
			{
				throw new FormatException(string.Format("Input string '{0}' was not in the correct format.", rs[index]), ex);
			}
		}
