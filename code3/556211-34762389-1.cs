    public class customer
    {
        public void InsertCustomer(string name,int age,string address)
        {
            // create and open a connection object
            using(SqlConnection Con=DbConnection.GetDbConnection())
            {
                // 1. create a command object identifying the stored procedure
                SqlCommand cmd = new SqlCommand("spInsertCustomerData",Con);
                // 2. set the command object so it knows to execute a stored procedure
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramName = new SqlParameter();
                paramName.ParameterName = "@nvcname";
                paramName.Value = name;
                cmd.Parameters.Add(paramName);
                SqlParameter paramAge = new SqlParameter();
                paramAge.ParameterName = "@inage";
                paramAge.Value = age;
                cmd.Parameters.Add(paramAge);
                SqlParameter paramAddress = new SqlParameter();
                paramAddress.ParameterName = "@nvcaddress";
                paramAddress.Value = address;
                cmd.Parameters.Add(paramAddress);
                cmd.ExecuteNonQuery();
            }
        }
    }
