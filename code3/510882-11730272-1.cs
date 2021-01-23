    using System.Collections.Generic;
    using System.Windows;
    using System.Windows.Documents;
    
    namespace GVButton
    {   
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
    
                List<Foo> _source = new List<Foo>();
                for (int i = 0; i < 10; i++)
                {
                    _source.Add(new Foo { ID = i, Name = "name_" + i });
                }
    
                listView.ItemsSource = _source;
            }
        }
    
        public class Foo
        {
            public int ID { get; set; }
            public string Name { get; set; }
        }
    }
