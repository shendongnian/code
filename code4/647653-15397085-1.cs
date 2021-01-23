    try
    {
      SqlConnection cn = new SqlConnection("Data Source=.\\SqlExpress;Initial Catalog=AllensCroft;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework;");
    
      cn.Open();
      SqlCommand Command = new SqlCommand(CreateInsertStatement(time_began_5,time_finished_5), cn);
      Command.Parameters.AddWithValue("date", date);
      Command.Parameters.AddWithValue("room", rooms_combo.SelectedValue);
      Command.ExecuteNonQuery();
      try
      {
         cn.Close();
      }
      catch (Exception e)
      {
         Console.WriteLine(e.ToString());
      }
    }
    catch (Exception e)
    {
       Console.WriteLine(e.ToString());
    }
