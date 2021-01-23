            List<Customer> cu = new List<Customer>();
            cu.Add(new Customer() {  Forename = "Onam" });
            grd1.DataSource = cu;
            grd1.DataBind();
    public class Customer
    {
        public string Forename { get; set; }
    }
