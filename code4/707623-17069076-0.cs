    private void BulkInsert(IEnumerable<Person> Persons)
    {
        // use the information in the link to get your connection
        DbConnection conn = ...
        using (DbCommand cmd = conn.CreateCommand())
        {
           var sb = new StringBuilder();
           sb.Append("INSERT INTO person (firstname, lastname) VALUES ");
           var count = 0;
           foreach(var person in persons)
           {
               if (count !=0) sb.Append(",");
               sb.Append(GetInsertCommand(person, count++, cmd));
           }
           
           if (count > 0)
           {
               cmd.CommandText = sb.ToString();
               cmd.ExecuteNonQuery();
           }
        }
       if (sb.Length > 0)
           ExecuteNonQuery(sb.ToString());
    }
    private string GetInsertCommand(Person person, int count, DbCommand cmd)
    {
        var firstname = "@firstname" + count.ToString();
        var lastname = "@lastname" + count.ToString();
        cmd.Parameters.Add(firstname, person.Firstname);
        cmd.Parameters.Add(lastname, person.Firstname);
        return String.Format("({0},{1})", firstname, lastname);
    }
