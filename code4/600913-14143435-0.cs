    // Assumes the following sql:
    //   SELECT foo, bar FROM baz
    // error checking left out for simplicity
    var list = new List<SomeClass>();
    using(var reader = cmd.ExecuteReader()) {
       while(reader.Read()) {
          list.Add(new SomeClass {
             // NOTE: you can see the columns that the c# is referencing
             //       and compare them to the sql statement being executed
             Foo = (string)reader["foo"],
             Bar = (string)reader["bar"]
          });
       }
    }
