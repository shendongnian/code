    private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;
    
            dataGridView1.Columns.Add("Name", "Name");
            dataGridView1.Columns.Add("City", "City");
            dataGridView1.Columns.Add("ContactName", "ContactName");
    
            dataGridView1.Columns["Name"].DataPropertyName = "Name";
            dataGridView1.Columns["City"].DataPropertyName = "Add_City";
            dataGridView1.Columns["ContactName"].DataPropertyName = "Cont_ContactName";
    
            List<Person> PersonList = PersonProxy.GetPersonCollection();
            
            //add them here
            System.ComponentModel.TypeDescriptor.AddProvider((new MyTypeDescriptionProvider<Address>()), typeof(Person));
            System.ComponentModel.TypeDescriptor.AddProvider((new MyTypeDescriptionProvider<Contact>()), typeof(Person));
            dataGridView1.DataSource = PersonList;
        }
              
    
