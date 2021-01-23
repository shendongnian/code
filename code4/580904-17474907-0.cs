    private void Form1_Load(object sender, EventArgs e)
    {
         AutoCompleteStringCollection resource = new AutoCompleteStringCollection();
         string searchTerm = (sender as TextBox).Text;    
         searchTb.AutoCompleteCustomSource = getResource(searchTerm);
    }
