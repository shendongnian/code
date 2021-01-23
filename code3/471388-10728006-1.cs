    using System;
    using System.Windows;
    using System.Windows.Controls.Primitives;
    
    namespace WpfApplication1
    {
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
            }
    
            private void ComboBox_DropDownClosed(object sender, EventArgs e)
            {
                MessageBox.Show((sender as Selector).SelectedItem.ToString());
            }
        }
    }
