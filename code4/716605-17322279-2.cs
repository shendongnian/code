    public class MyCollection
    {
         private DataTable loadedData = null;
         public MyCollection()
         {
             loadedData = new DataTable();
             loadedData.Columns.Add("Column1", typeof(string));
             .... and so on for every field expected
         }
         // A property to return the collected data
         public DataTable GetData
         {
            get{return loadedData;}
         }
    
         public void readIn(string line)
         {
              // split the line in fields
              DataRow r = loadedData.NewRow();
              r["Column1"] = splittedLine[0];
              .... and so on
              loadedData.Rows.Add(r);
         }
    }
