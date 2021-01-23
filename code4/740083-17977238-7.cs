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
    using System.Collections;
    namespace stackoverflowTreeview
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
                Data = new ArrayList() { false, 5 };
            
            }
            public static DependencyProperty dData = DependencyProperty.Register("Data",     typeof(ArrayList), typeof(MainWindow));
            public ArrayList Data
            {
                get { return (ArrayList)GetValue(dData); }
                set { SetValue(dData, value); }
            }
        }
    }
