    public class CustomerProvider
    {
        public int UpdateCustomer(int id, string name, string address)
        {
            using(connection = new
                SqlConnection("Server=localhost;DataBase=Northwind;Integrated Security=SSPI"))
            {
                connection.Open();
                var command = new SQLCommand("csp_updatecustomer", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(
	            new SqlParameter("@CustomerID", id));
                command.Parameters.Add(
                    new SqlParameter("@CustomerName", name));
                command.Parameters.Add(
                    new SqlParameter("@CustomerAddress", address));
                var result = command.ExecuteNonQuery();
                return result;
            }
        }
    }
