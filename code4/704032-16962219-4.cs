    using (var conn = new SqlConnection("...").AutoOpen())
    {
        // prepare a fresh new database
        conn.Execute("if exists (select * from sysdatabases where name = 'SO16962113') drop database SO16962113");
        conn.Execute("create database SO16962113");
        conn.Execute("use SO16962113");
        
        // execute some queries
        conn.Execute("create table persons (person_id int primary key not null identity(1,1), person_name varchar(100))");
        conn.Execute("insert into persons (person_name) values ('James'), ('Jon'), ('Mary'), ('Jack')");
        conn.Query<Person>("select * from persons where person_id in (@id1, @id2)", new { id1 = 2, id2 = 4 }).Dump();
        
        // clean up
        conn.Execute("use master");
        conn.Execute("drop database SO16962113");
    }
