    class Program
    {
            static void Main(string[] args)
            {
            // I have used hardcoded values representing database values
            var dataTable = new DataTable();
            dataTable.Columns.Add(new DataColumn("Column1"));
            dataTable.Columns.Add(new DataColumn("Column2"));
            var row = dataTable.NewRow();
            row[0] = 1;
            row[1] = "Test Value";
            dataTable.Rows.Add(row);
            // This list below contains properties - variables , with same datatype and value
            dynamic parentList = new List<dynamic>();
            var rowOne = dataTable.Rows[0]; 
            for (int i = 0; i < dataTable.Columns.Count; i++)
            {
                dynamic child= new ExpandoObject();
                child.Property = Convert.ChangeType(row[i], row[i].GetType());
                parentList.Add(child); 
            }
        }
    }
