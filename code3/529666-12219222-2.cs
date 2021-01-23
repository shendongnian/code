    public partial class MyMiddleControl : UserControl
    {
      public MyMiddleControl() {
        this.DataContext = this;
        this.InitializeComponent();
      }
    
      public static readonly DependencyProperty GroupNameProperty =
        DependencyProperty.Register("GroupName", typeof(string),
                                    typeof(MyMiddleControl),
                                    new PropertyMetadata("default"));
    
      public string GroupName {
        get { return (string)this.GetValue(GroupNameProperty); }
        set { this.SetValue(GroupNameProperty, value); }
      }
    }
    <UserControl x:Class="TestBind.MyMiddleControl"
                 xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
                 xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
                 x:Name="middleControl">
        <Grid>
            <TextBlock Height="40" HorizontalAlignment="Left" Margin="45,23,0,0" 
                       Name="textBlock1" Text="{Binding ElementName=middleControl, Path=GroupName}" 
                       VerticalAlignment="Top" Width="203" />
        </Grid>
    </UserControl>
    public partial class MyGlobalControl : UserControl, INotifyPropertyChanged
    {
      public MyGlobalControl() {
        this.DataContext = this;
        this.InitializeComponent();
        this.MyText = "myDef";
      }
    
      public string _myText;
      public string MyText {
        get { return this._myText; }
        set {
          this._myText = value;
          this.OnPropertyChanged("MyText");
        }
      }
    
      public event PropertyChangedEventHandler PropertyChanged;
    
      protected virtual void OnPropertyChanged(string propertyName) {
        PropertyChangedEventHandler handler = this.PropertyChanged;
        if (handler != null) {
          handler(this, new PropertyChangedEventArgs(propertyName));
        }
      }
    
      private void button1_Click(object sender, RoutedEventArgs e) {
        this.MyText = "btnClick";
      }
    }
    <UserControl x:Class="TestBind.MyGlobalControl"
                 xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
                 xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
                 xmlns:my="clr-namespace:TestBind"
                 x:Name="globalControl">
      <Grid>
        <my:MyMiddleControl HorizontalAlignment="Left"
                            Margin="24,82,0,0"
                            x:Name="myFloatTest"
                            GroupName="{Binding ElementName=globalControl, Path=MyText}"
                            VerticalAlignment="Top" />
        <Button Content="Button"
                Height="23"
                HorizontalAlignment="Left"
                Margin="296,65,0,0"
                Name="button1"
                VerticalAlignment="Top"
                Width="75"
                Click="button1_Click" />
      </Grid>
    </UserControl>
