    List<SqlParameter> parameters = new List<SqlParameter>
    {    
      new SqlParameter("@first_name", SqlDbType.VarChar, 50) { Value = to.FirstName },
      new SqlParameter("@last_name", SqlDbType.VarChar, 50) { Value = to.LastName },
      new SqlParameter("@middle_name", SqlDbType.VarChar, 50) { Value = to.MiddleName },
      new SqlParameter("@empid", SqlDbType.Int) { Value = to.EmpId }
    };
