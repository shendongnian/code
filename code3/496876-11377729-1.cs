    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Navigation;
    using System.Windows.Shapes;
    
    namespace DataGrid
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
    
                List<container> _source = new List<container>();
    
                for (int i = 0; i < 10; i++)
                {
                    _source.Add(new container("test", 1 * 10, 1 * 10000));
                }
    
                dgData.ItemsSource = _source;
            }
        }
    
        public struct container
        {
            public container(string sticker, decimal volatility, decimal rateofreturn)
            {
                this.sticker = sticker;
                this.volatility = volatility;
                this.rateofreturn = rateofreturn;
            }
            string sticker;
            decimal volatility;
            decimal rateofreturn;
    
            public string Sticker { get { return sticker; } set { sticker = value; } }
            public decimal Volatility { get { return volatility; } set { volatility = value; } }
            public decimal Rateofreturn { get { return rateofreturn; } set { rateofreturn = value; } }
        };
    }
