      var nullableparam = new SqlParameter("@myfield", DBNull.Value);
      nullableparam.IsNullable = true;
      nullableparam.SqlDbType = SqlDbType.DateTime;
      nullableparam.Direction = ParameterDirection.Input;
      cm.Parameters.Add(nullableparam);
