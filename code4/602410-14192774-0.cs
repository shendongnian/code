    try
    {
        string connectionString = "Data Source=.\\SQLEXPRESS;" + 
                                  "Initial Catalog=lrmg;Integrated Security=True;";
        using(SqlConnection sqlConn = new SqlConnection(connstring))
        {
            SqlCommand cmd = sqlConn.CreateCommand();**
            cmd.CommandText = "INSERT INTO Canditate(Name, Doj) VALUES(@name, @dt)";
            cmd.Parameters.AddWithValue("@name", txtName.Text);
            cmd.Parameters.AddWithValue("@dt", Convert.ToDateTime(txtDate.Text));
            cmd.ExecuteNonQuery();
            labMessage.Text = "The value was inserted into your database";
        }
    }
    catch (SqlException sqlE)
    {
        labMessage.Text = sqlE.Message;
    }
    catch (Exception exe)
    {
        labMessage.Text = exe.Message;
    }
