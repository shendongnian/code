    static void foo() {
      var command = new SqlCommand();
      command.Parameters.Add("@Name", SqlDbType.NVarChar, 50).Value = "";
    }
    static void bar() {
      var command = new SqlCommand();
      var cp = command.Parameters;
      cp.Add("@Name", SqlDbType.NVarChar, 50).Value = "";
    }
