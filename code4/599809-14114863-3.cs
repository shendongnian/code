    public static void FillDropDownList(string Query, System.Windows.Forms.ComboBox DropDownName)
    {
      DataTable dt;
      using (var cn = new SqlConnection(CONNECTION_STRING))
      {
        cn.Open();
        try
        {
          SqlCommand cmd = new SqlCommand(Query, cn);
          dt = cmd.ExecuteQuery();
        }
        catch (SqlException e)
        {
          Console.WriteLine(e.ToString());
          return;
        }
      }
      DropDownName.DataSource = dt;
      DropDownName.ValueMember = "id";
      DropDownName.DisplayMember = "Name";
    }
