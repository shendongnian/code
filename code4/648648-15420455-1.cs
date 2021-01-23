    using System.Windows;
    using System.Linq;
    namespace WpfApplication4
    {
        public partial class Window18 : Window
        {
            public Window18()
            {
                InitializeComponent();
    
                DataContext = Enumerable.Range(0, 20).Select(x => "Item" + x);
            }
        }
    }
