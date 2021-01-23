    try
    {
        SqlConnection conn = new SqlConnection(connString);
        conn.Open();
        sqlString = "SELECT Vare.varenavn";
        sqlString += " FROM vare";
        sqlString += " ORDER BY vare.varenavn";
        SqlCommand cmd = new SqlCommand(sqlString, conn);
        SqlDataReader reader =
        cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
        List<string> strList = new List<string>();
        while (reader.Read())
        {
            string temp = reader.GetString(0);
            strList.Add(temp);
            Console.WriteLine(reader.GetString(0));
        }
        reader.Close();
        conn.Close();
       //code to write list to text file
       File.WriteAllLines(Application.StartupPath + "\\text.txt", strList.ToArray());
    }
    catch (System.Data.SqlClient.SqlException e)
    {
        Console.WriteLine(e.ToString());
    }
