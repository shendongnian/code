    <ComboBox Name="CbCategory" ItemsSource="{Binding Categories}"
        SelectedItem="{Binding SelectedCategory.Name, UpdateSourceTrigger=PropertyChanged}"
        Text="{Binding Name}" DisplayMemberPath="Name" 
        IsEditable="True"/>
    
    private String _name;
    public Category Name
    {
        get { return _name; }
    
        set
        {        
             _name = value
             SendPropertyChanged("Name");
        }
    }
    
    public ICommand ItemChange
    {
     get
     {
       `return new RelayCommand(() =>`{
                        try{string item = this.SelectedCategory.Code;}
    catch(Exception ex){string item = this.Name;}
                    }, () => { return true; });
                }
            }
