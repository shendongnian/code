    class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public override string ToString( )
        {
            return "Person, name=" + FirstName + " Surname=" + LastName;
        }
    }
    
    ...
    
    public Form1( )
    {
      InitializeComponent( );
      dataGridView1.RowsAdded += new DataGridViewRowsAddedEventHandler( dataGridView1_RowsAdded );
      dataGridView1.DataSource = new Person[]{ new Person{ FirstName= "Jarek", LastName= "Mitek"},
                                               new Person{ FirstName= "Tony", LastName= "Montana"}};
    }
    void dataGridView1_RowsAdded( object sender, DataGridViewRowsAddedEventArgs e )
    {
      Console.WriteLine( "Rows added count: " + e.RowCount + " row index: " +e.RowIndex );
      Console.WriteLine( dataGridView1.Rows[ e.RowIndex ].DataBoundItem.ToString( ) );
    }
