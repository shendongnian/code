    public Window()
    {
          this.DataContext = this;
          InitializeComponent();
    }
    public string Name {get;}
    //xaml
    <TextBlock Text="{Binding Name}"/>
 
