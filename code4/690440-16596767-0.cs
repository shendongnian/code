    class Program
    {
        static void Main(string[] args)
        {
            DataSet ds = new DataSet();
            DataTable dt = ds.Tables.Add("Table");
            dt.Columns.Add("Id");
            for (int i = 0; i < 10; i++)
            {
                dt.Rows.Add(new object[]{i});
            }
            var newRow=dt.NewRow();
            newRow.ItemArray=new string[]{(dt.Rows.Count/2).ToString()+".middle"};
            dt.Rows.InsertAt(newRow, dt.Rows.Count / 2);
        }
    }
