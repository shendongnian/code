    try
    {
      cmd.ExecuteNonQuery();
      con2.Close();
      MessageBox.Show("Thanks");
    }
    catch (SqlException ex)
    {
       for (int i = 0; i < ex.Errors.Count; i++)
       {
            if (ex.Errors[i].Message.Contains("There is already an object named"))
            {
                 /* Handle duplicate situation here */
                 break;
            }
       }
    }
    catch (Exception ex)
    {
      MessageBox.Show(ex.Message);
      con.Close();
    }
