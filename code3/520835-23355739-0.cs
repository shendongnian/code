            con.Open();
            cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = spname;
            cmd.CommandType = CommandType.StoredProcedure;
            reader = cmd.ExecuteReader();
            List<EmployeeDetails> lstemp = new List<EmployeeDetails>();
            while (reader.Read())
            {
                EmployeeDetails emp = new EmployeeDetails();
                emp.EmployeeId =Convert.ToInt32( reader["EmployeeId"].ToString());
                emp.FirstName = reader["FirstName"].ToString();
                emp.LastName = reader["LastName"].ToString();
                emp.DOB = Convert.ToDateTime(reader["DOB"].ToString());
                emp.Gender = Convert.ToInt32(reader["Gender"].ToString());
                emp.QName = reader["QName"].ToString();
                emp.Dname = reader["DName"].ToString();
                emp.Email = reader["Email"].ToString();
               
                lstemp.Add(emp);
            }
            return lstemp;
        }
