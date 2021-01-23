    using System.Collections.Generic;
    using System.Windows;
    using System.Linq;
    
    namespace WpfApplication1
    {
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
                cb.DataContext = new[] 
                {
                    new { Title="title1", Image=@"C:\img001.jpg" },
                    new { Title="title2", Image=@"C:\img002.jpg" }
                };
            }
        }
    }
