    public class CustomDialog
    {
        List<Customer> _customerList;
        public CustomDialog(List<Customer> customers)
        {
            _customerList = customers;
        }
        private void CustomDialog_Load(object sender, EventArgs e)
        {
             comboBox1.DataSource = _customerList; 
             comboBox1.ValueMember = "Id";  // Supposing the Customer object contains ID property
             comboBox1.DisplayMember = "ClientName";   // The property shown on the combobox items
        }
    }
