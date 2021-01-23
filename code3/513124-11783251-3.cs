    List<SqlParameter> parameters = new List<SqlParameter>
    {    
      new SqlParameter("@first_name", SqlDbType.VarChar, 50).WithValue(to.FirstName),
      new SqlParameter("@last_name", SqlDbType.VarChar, 50).WithValue = to.LastName)
      new SqlParameter("@middle_name", SqlDbType.VarChar, 50).WithValue(to.MiddleName),
      new SqlParameter("@empid", SqlDbType.Int).WithValue(to.EmpId)
    };
