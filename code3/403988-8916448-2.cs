    public class Coupon
    {
        public int Foo { get; set; }
        public int Bar { get; set; }
    }
    
    public class CouponRepository
    {
        private readonly string connectionString;
    
        public CouponRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }
    
        public IEnumerable<Coupon> GetCoupons()
        {        
            using(var conn = new SqlConnection(this.connectionString))
            using(var cmd = new SqlCommand("CPC_GetAllCoupons", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();
                
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        yield return new Coupon
                        {
                            Foo = (int)reader["Foo"],
                            Bar = (int)reader["Bar"],
                        };
                    }
                }
            }
        }
    }
