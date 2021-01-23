            List<Customer> cu = new List<Customer>();
            cu.Add(new Customer() {  Forename = "Onam" });
            gridView1.DataSource = cu;
            gridView1.DataBind();
    public class Customer
    {
        public string Forename { get; set; }
    }
