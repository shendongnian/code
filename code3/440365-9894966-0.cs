    using (EntityConnection conn = new EntityConnection("name=SampleEntities"))
    {
        conn.Open();
        EntityCommand cmd = conn.CreateCommand();
        cmd.CommandText = "SELECT VALUE c FROM SampleEntities.Contacts AS c WHERE c.FirstName='Robert'";
        using (EntityDataReader rdr = cmd.ExecuteReader(CommandBehavior.SequentialAccess | CommandBehavior.CloseConnection))
        {
            while (rdr.Read())
            {
                var firstname = rdr.GetString(1);
                var lastname = rdr.GetString(2);
            }
        }
        conn.Close();
    }
