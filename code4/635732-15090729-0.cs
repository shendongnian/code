    public class KitList : List<Kit>
    {
      public void FillList()
      {
        using (SqlConnection con = new SqlConnection(""))
        {
          var cmd = new SqlCommand("GetData", con);
          var dt = new DataTable();
          var sda = new SqlDataAdapater(cmd);
          sda.Fill(dt);
          foreach(var row in dt.Rows)
          {
            Kit k = new Kit();
            foreach(var col in dt.Columns)
            {
              k.GetType().GetProperty(col.Name).SetValue(obj, row[col.Name], null);
            }
            this.Add(k);
          }
        }
      }
    }
