    using System.Windows;
    using StockQuoteExample.ViewModel;
    
    namespace StockQuoteExample
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
    
                this.DataContext = new StockQuoteViewModel();
            }
        }
    }
