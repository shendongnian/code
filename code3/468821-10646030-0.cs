    class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
    
    ...
    
    public Form1( )
    {
      InitializeComponent( );
      dataGridView1.DataSource = new Person[]{ new Person{ FirstName= "Jarek", LastName= "Mitek"},
                                               new Person{ FirstName= "Tony", LastName= "Montana"}};
    }
