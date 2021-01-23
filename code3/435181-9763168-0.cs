    <Window x:Class="WpfApplication1.MainWindow"
            xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
            xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
            Title="MainWindow" Height="350" Width="525">
        <Grid>
    		<TextBox x:Name="txt_density" Text="{Binding SomeText}"  />
    	</Grid>
    </Window>
    
    
    namespace WpfApplication1
    {
    	/// <summary>
    	/// Interaction logic for MainWindow.xaml
    	/// </summary>
    	public partial class MainWindow : Window
    	{
    		public MainWindow()
    		{
    			InitializeComponent();
    
    			SomeText = "blah";
    			this.DataContext = this;
    			this.Loaded += new RoutedEventHandler(MainWindow_Loaded);
    		}
    
    		void MainWindow_Loaded(object sender, RoutedEventArgs e)
    		{
    			Binding binding = BindingOperations.GetBinding(txt_density, TextBox.TextProperty);
    			binding.ValidationRules.Clear();
    			//binding.ValidationRules.Add(new MainWindow.Float_Positive_ValidationRule());
    		}
    
    		public string SomeText { get; set; }
    
    	}
    }
