    using System.Collections.Generic;
    using System.Windows;
    using System.Windows.Documents;
    
    namespace ListBoxItems
    {	
    	public partial class MainWindow : Window
    	{
    		public MainWindow()
    		{
    			InitializeComponent();
    
    			List<MyBoundObject> _source = new List<MyBoundObject>();
    			for (int i = 0; i < 100000; i++)
    			{
    				_source.Add(new MyBoundObject { Label = "label " + i });
    			}
    			lbData.ItemsSource = _source;
    		}
    
    		private void Button_Click(object sender, RoutedEventArgs e)
    		{
    			MessageBox.Show(lbData.SelectedItems.Count.ToString());
    		}
    
    		private void Button_Click_1(object sender, RoutedEventArgs e)
    		{
    			int num = 0;
                foreach (MyBoundObject item in lbData.Items)
    	        {
                    if (item.IsSelected) num++;
    	        }
    
                MessageBox.Show(num.ToString());
    		}
    	}
    
    	public class MyBoundObject
    	{
    		public string Label { get; set; }
            public bool IsSelected { get; set; }
    	}
    }
