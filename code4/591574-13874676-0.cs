    class TableComparer : EqualityComparer<DataRow>
	{
		public override bool Equals(DataRow c1, DataRow c2)
		{
			if (c1["field1"] == c1["field1"] &&
			    c1["field2"] == c1["field2"])
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		public override int GetHashCode(DataRow c)
		{
			int hash = 23;
			hash = hash * 37 + c["field1"].GetHashCode();
			hash = hash * 37 + c["field2"].GetHashCode();
			return hash;
		}
	}
        TableComparer eqc = new TableComparer();
        var newValues = tempList.Rows.Cast<DataRow>().Distinct(eqc).ToList();
    
    SqlBulkCopy bulkcopy = new SqlBulkCopy(sqlDB1Connection)
    bulkcopy.DestinationTableName = "dbo.tblOrdersDB1";
    bulkcopy.WriteToServer(newValues);
