    using (var sqlCommand = new SqlCommand(SelectMembers, sqlConnection)) {
        // fetch data and iterate through results
        var reader = sqlCommand.ExecuteReader();
        while (reader.Read()) { 
            // create an object, set its properties and add it to the return list
            Member member = new Member();
            member.SomeProperty = reader["MY_COLUMN"];
            list.Add(member);
        }
    }
