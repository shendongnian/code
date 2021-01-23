    public class ColorBehavior : Behavior<Border>
	{
		public Brush OriginalBrush { get; set; }
		protected override void OnAttached()
		{
			base.OnAttached();
			this.OriginalBrush = this.AssociatedObject.Background;
			this.AssociatedObject.Background = Brushes.CadetBlue;
		}
		protected override void OnDetaching()
		{
			base.OnDetaching();
			this.AssociatedObject.Background = this.OriginalBrush;
		}
	}
    public partial class MainWindow : Window
	{
		private ColorBehavior behavior = new ColorBehavior();
		private bool isAttached;
		public MainWindow()
		{
			InitializeComponent();
		}
		private void Button_Click(object sender, RoutedEventArgs e)
		{
			if (!this.isAttached)
			{
				this.behavior.Attach(this.Border);
				this.isAttached = true;
			}
			else
			{
				this.behavior.Detach();
				this.isAttached = false;
			}
		}
	}
    <Window x:Class="WpfApplication1.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:i="http://schemas.microsoft.com/expression/2010/interactivity"
        xmlns:local="clr-namespace:WpfApplication1"
        Title="MainWindow"
        Width="525"
        Height="350">
	<Grid>
		<Border x:Name="Border" Background="Red" />
		<Button Width="50"
		        Height="20"
		        Click="Button_Click"
		        Content="Hey" />
	</Grid>
