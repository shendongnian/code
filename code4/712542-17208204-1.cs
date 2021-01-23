    // in Form1.cs
    private void btn_Click(object sender, System.EventArgs e) 
    {
        string customerCode=someTextBox.Text;
        var cs = new CustomerRepository();
    
        string customerName=cs.SearchCustomerByCode(customerCode);
        someOtherTextBox.Text=customerName;
    }
    
    // in CustomerRepository.cs
    //... logic to get the data from the DB, no specific knowledge of form1
    public class CustomerRepository.cs 
    {
        public string SearchCustomerByCode(string customerCode)
        {
          //...
        }
    }
