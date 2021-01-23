    public Window()
    {
          this.DataContext = this;
          InitializeComponent();
    }
    public string Name {get;set;}
    //xaml
    <TextBlock Text="{Binding Name}"/>
 
