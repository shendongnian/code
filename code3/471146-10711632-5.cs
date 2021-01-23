       public Form1()
        {
            InitializeComponent();
    
            List<Name> namesList = new List<Name>();
            dataGridView1.AutoGenerateColumns = false;
            DataGridViewTextBoxColumn firstNameColumn = new DataGridViewTextBoxColumn();
            makeColumn.DataPropertyName = "First";
            makeColumn.HeaderText = "First Name";
            DataGridViewTextBoxColumn middleNameColumn = new DataGridViewTextBoxColumn();
            modelColumn.DataPropertyName = "Middle";
            modelColumn.HeaderText = "Middle Name";
            DataGridViewTextBoxColumn lastNameColumn = new DataGridViewTextBoxColumn();
            yearColumn.DataPropertyName = "Last";
            yearColumn.HeaderText = "Last Name";
            dataGridView1.Columns.Add(firstNameColumn);
            dataGridView1.Columns.Add(middleNameColumn);
            dataGridView1.Columns.Add(lastNameColumn);
            for (int i = 0; i < names.getNames().Length; i++)
            {
                // TODO create new Name object. 
                // TODO set properties in new Name object accordingly.
                // TODO add name object to namesList once properties have been set.
            }
    
            dataGridView1.DataSource = namesList;
        }
