    namespace WpfApplication1
    {
    	using System.Collections.ObjectModel;
    
    	/// <summary>
    	/// Interaction logic for Window1.xaml
    	/// </summary>
    	public partial class Window1 : Window
    	{
    		private readonly ObservableCollection<Info> _validInfo;
    
    		public Window1()
    		{
    			_validInfo = new ObservableCollection<Info>();
    			InitializeComponent();
    			this.DataContext = this;
    			var info = new Info();
    			info.Foreground = Brushes.Red;
    			info.Visible = true;
    			info.Channel = "not sure";
    			_validInfo.Add(info);
     			info = new Info();
		     	info.Foreground = Brushes.Blue;
	     		info.Visible = true;
     			info.Channel = "also not sure";
     			_validInfo.Add(info);
    
    		}
    
    		public ObservableCollection<Info> Infos { get { return _validInfo; } }
    	}
    
    	public class Info : DependencyObject
    	{
    		public Brush Foreground
    		{
    			get { return (Brush)GetValue(TextBlock.ForegroundProperty); }
    			set { SetValue(TextBlock.ForegroundProperty, value); }
    		}
    
    		public bool Visible { get; set; }
    		public string Channel { get; set; }
    
    		public override string ToString()
    		{
    			return string.Format("{0}-{1}-{2}", Channel, Foreground, Visible);
    		}
    	}
    }
