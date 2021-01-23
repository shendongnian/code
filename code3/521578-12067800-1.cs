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
    
    namespace RadarControls
    {
        /// <summary>
        /// Interaction logic for RadarDataGrid.xaml
        /// </summary>
        public partial class RadarDataGrid : UserControl
        {
            public RadarDataGrid()
            {
                InitializeComponent();
            }
            public DataGrid RadarGrid//New Public Class is added
            {
                get { return myGrid; }
            }
        }
    }
