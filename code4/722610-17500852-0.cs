    class CustomGrid: DataGridView
    {
       public new List<Employee> DataSource 
       {
              get { return (List<Employee>)base.DataSource;}
              set { base.DataSource = value;}
       }   
    }
