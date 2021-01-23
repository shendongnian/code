    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Navigation;
    using System.Windows.Shapes;
    using System.Threading;
    
    using System.Collections.ObjectModel;
    
    namespace WpfApplication1
    {
    	/// <summary>
    	/// Logica di interazione per MainWindow.xaml
    	/// </summary>
    	public partial class MainWindow : Window
    	{
    		public static readonly DependencyProperty MyListProperty = DependencyProperty.Register("MyList", typeof(ObservableCollection<string>), typeof(MainWindow));
    
    		public ObservableCollection<string> MyList
    		{
    			get
    			{
    				return (ObservableCollection<string>)GetValue(MyListProperty);
    			}
    			set
    			{
    				SetValue(MyListProperty, value);
    			}
    		}
    		public MainWindow()
    		{
    			InitializeComponent();
    
    			MyList = new ObservableCollection<string>() { "a", "b" };
    			MyList.Add("c");
    		}
    	}
    }
