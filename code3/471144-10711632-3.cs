       public Form1()
        {
            InitializeComponent();
    
            List<Name> namesList = new List<Name>();
    
            for (int i = 0; i < names.getNames().Length; i++)
            {
                // TODO create new Name object. 
                // TODO set properties in new Name object accordingly.
                // TODO add name object to namesList once properties have been set.
            }
    
            dataGridView1.DataSource = namesList;
        }
