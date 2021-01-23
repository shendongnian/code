    // this is the class you going to use to transfer data across the layers 
    public class Customer
    {
        public DateTime Registered_Date { get; set; }
        public string FirstName { get; set; }
        //so on...
        
    }
    public class CustomerDataAccess
    {
        public static void insertCustomer(Customer customer)
        {
            using (var con = new SqlConnection("Data Source=LAKHE-PC;Initial Catalog=Sahakari;Integrated Security=True"))
            using (var cmd = con.CreateCommand())
            {
                con.Open();
                cmd.CommandText = "sp_registerCust";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Registered_Date", customer.Registered_Date);
                cmd.Parameters.AddWithValue("@FirstName", customer.FirstName);
                // so on...
                cmd.ExecuteNonQuery();
               
            }
            
        }
        internal static bool Validate(Customer customer)
        {
            // some validations before insert 
        }
    }
