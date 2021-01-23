    public class CustomerService
    {
      public DataTable ShowCustomers()
      {
        string cns = "data source=.; database=custer; user id=sa; password=*****";
        SqlConnection conn = new SqlConnection(cns);
        SqlDataAdapter da = new SqDataAdapter("select * from Customers", conn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
      }
    }    
    private void button1_Click(object sender, EventArgs e)
    {
       CustomerService service = new CustomerService();
       if (txtCustomerName.Text != "" || txtCustomerSurname.Text != "")
       {
         customerservice.customerAdd(txtCustomerName.Text,txtCustomerSurname.Text);
          MessageBox.Show("Customer Added");
          DataTable dt = service.ShowCustomers();
          Form1.dataGridView1.DataSource = dt;
          //If you also need customer list. Provide the DataTable and get list
          List<Customers> customers = new List<Customers>();        
          for (int i=0;i<dt.Rows.Count;i++)
          {
            Customer customer = new Customer();            
            customer.CustomerID = Convert.ToInt32(dt.Rows[i][0]);
            customer.CustomerName = dt.Rows[i][1].ToString();
            customer.CustomerSurname = dt.Rows[i][2].ToString();
            customers.Add(customer);
          }
       }
    }
