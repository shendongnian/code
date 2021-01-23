    try{
    SqlDataReader dReader;
                SqlCommand cmd = new SqlCommand(procedure, con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                dReader = cmd.ExecuteReader(); // This is the last place my bullet check gets before it hop's out!
                if (dReader.HasRows == true)
                {
                    while (dReader.Read())
                        namesCollection.Add(dReader["SystemUser"].ToString());
                }
                con.Close();
                dReader.Close();
    }
    catch(Exception e)
    {
        // handle the exception better than me :)
        Console.WriteLine(e.Message);
    }
