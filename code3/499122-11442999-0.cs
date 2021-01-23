    //Set up the DataGridView either via code behind or the designer
    DataGridView dgView = new DataGridView();
    
    //You should turn off auto generation of columns unless you want all columns of
    //your bound objects to generate columns in the grid
    dgView.AutoGenerateColumns = false; 
    
    //Either in the code behind or via the designer you will need to set up the data
    //binding for the columns using the DataGridViewColumn.DataPropertyName property.
    DataGridViewColumn column = new DataGridViewColumn();
    column.DataPropertyName = "PropertyName"; //Where you are binding Foo.PropertyName
    dgView.Columns.Add(column);
    //You can bind a List<Foo> as well, but if you later add new Foos to the list 
    //reference they won't be updated in the grid.  If you use a binding list, they 
    //will be.
    BindingList<Foo> listOfFoos = Repository.GetFoos();
    
    dgView.DataSource = listOfFoos;
