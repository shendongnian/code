    Customer cust = new Customer();
    cust = client.getCategori(tbEmpID.Text); // this method only return one customer 
    var list = new List<Customer> { cust };
    GridView1.DataSource=list;
    GridView1.DataBind();
