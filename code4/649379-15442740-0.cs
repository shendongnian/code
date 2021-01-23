    protected void buttonSearch_Click(object sender, EventArgs e)
    {
      using (var context = new NorthwindDataContext())
      {
        var customers =
          from c in context.Customers
          select c;
    
        gridViewCustomers.DataSource = customers;
        gridViewCustomers.DataBind();
      }
    }
