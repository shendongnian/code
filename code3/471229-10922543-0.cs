    /// if you use OfType Method then you will get advantage of to use as normal control
    /// means this method will give you advantage of can use all method and properties
    /// of the control which you want to implement in DataGridView
    
    /// Controls.OfType method will check all the columns and get an array with 
    /// what you give as search criteria..here, the criteria is ComboboxColumn..
    /// depends of your need you can give comboboxcell also..
    
    /// Element at method selects the zero based index in array which filtered by criteria
    /// if you use only one of the given type then you can use .First() instead of .ElementAt()
    
    
    yourDataGridViewName.Controls.OfType<DataGridViewComboBoxColumn>()
    .ElementAt(indexNoOfTheDGVComboBox).DataSource = YourDataRetrievingMethod; 
    //i.e. ds.Tables[indexNoOfTheTable].Columns[IndexOfTheColumn]
    
    /// and you can set DisplayMember and ValueMember as the same way.. 
    /// i give combocell and combocolumn together to show the syntax.
    
    yourDataGridViewName.Controls.OfType<DataGridViewComboBoxCell>()
    .ElementAt(0).DisplayMember = "YourDisplay";
    
    yourDataGridViewName.Controls.OfType<DataGridViewComboBoxCell>()
    .ElementAt(0).ValueMember = "YourValue"; 
