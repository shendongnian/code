    public static class ConverterExtensions
    {
         public static void LoadFromDataRow<UserData>(UserData data, DataRow row)
         {
             data.Name = Convert.ToString(row.Table.Columns.Contains("Name") ? row["Name"] : row[0]);
             data.Age = Convert.ToInt32(row.Table.Columns.Contains("Age") ? row["Age"] : row[1]);
             data.City = Convert.ToString(row.Table.Columns.Contains("City") ? row["City"] : row[2] );
         }
    }
