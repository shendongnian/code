       public Form1()
        {
            InitializeComponent();
    
            List<Name> namesList = new List<Name>();
    
            for (int i = 0; i < names.getNames().Length; i++)
            {
                // TODO create new Name object. 
                   Set properties accordingly.
                   Add name object to namesList.
            }
    
            dataGridView1.DataSource = namesList;
        }
