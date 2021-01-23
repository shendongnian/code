    public static void FillDropDownList(string Query, System.Windows.Forms.ComboBox DropDownName)
    {
      SqlConnection myConnection = new SqlConnection(CONNECTION_STRING);
      try
      {
        myConnection.Open();
        SqlCommand cmd = new SqlCommand(Query, myConnection);
        DataTable dt = cmd.ExecuteQuery();
      }
      catch (SqlException e)
      {
        Console.WriteLine(e.ToString());
        return;
      }
      finally
      {
        myConnection.Close();
      }
      DropDownName.DataSource = dt;
      DropDownName.ValueMember = "id";
      DropDownName.DisplayMember = "Name";
    }
