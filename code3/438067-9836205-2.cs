    public interface ILoadFromDataRow<T>
    {
         void LoadFromDataRow<T>(T object, DataRow dr);
    }
    
    public class UserLoadFromDataRow : ILoadFromDataRow<UserData>
    {
         public void LoadFromDataRow<UserData>(UserData data, DataRow dr)
         {
            data.Name = Convert.ToString(row.Table.Columns.Contains("Name") ? row["Name"] : row[0]);
            data.Age = Convert.ToInt32(row.Table.Columns.Contains("Age") ? row["Age"] : row[1]);
            data.City = Convert.ToString(row.Table.Columns.Contains("City") ? row["City"] : row[2] );
         }
    }
    
    public class UserData
    {
        private ILoadFromDataRow<UserData> converter;
    
        public UserData(DataRow dr = null, ILoadFromDataRow<UserData> converter = new LoadFromDataRow<UserData>())
        {
             this.converter = (converter == null ? new LoadFromDataRow<UserData>() : converter);
    
             if(dr!=null)
                 this.converter.LoadFromDataRow(this,dr);
        }
        
        // POCO as before
    }
