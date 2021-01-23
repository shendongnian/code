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
    using System.Data;
    using System.IO;
    
    
    namespace Splash
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            DataLoader dataTable = new DataLoader();
    
            public MainWindow()
            {
                string path = @"C:\Users\Lyukshins\Dropbox\PROGRAM_TEST\AUTOMATION\DATA\Database.csv";
                FileInfo theFile = new FileInfo(path);
                dataTable = new DataLoader();
                DataTable table = dataTable.GetDataTableFromCsv(theFile);
                InitializeComponent();
                viewGrid(table);
                
            }
    
            private void viewGrid(DataTable table)
            {        
                if (table.Columns.Count == 0)
                    MessageBox.Show("Error!");
                else
                    dataGrid.ItemsSource = table.DefaultView;
            }
    
    
            private void Data_Table(object sender, SelectionChangedEventArgs e)
            {
                string path = @"C:\Users\Lyukshins\Dropbox\PROGRAM_TEST\AUTOMATION\DATA\Database.csv";
                FileInfo theFile = new FileInfo(path);
                dataTable = new DataLoader();
                DataTable table = dataTable.GetDataTableFromCsv(theFile);                        
            }
    
            private void Copy_Files_Click(object sender, RoutedEventArgs e)
            {
    
            }
    
            private void Rename_Click(object sender, RoutedEventArgs e)
            {
    
            }
        }
    }
