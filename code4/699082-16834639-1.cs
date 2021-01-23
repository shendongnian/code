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
    using System.Windows.Shapes;
    using System.Data;
    using System.ComponentModel;
    
    namespace TempTest
    {
        /// <summary>
        /// Interaction logic for DataTableTest.xaml
        /// </summary>
        public partial class DataTableTest : Window
        {
            public DataTableTest()
            {
                InitializeComponent();
                textBox2.LostFocus += new RoutedEventHandler(textBox2_LostFocus);
            }
    
            void textBox2_LostFocus(object sender, RoutedEventArgs e)
            {
                if (!string.IsNullOrWhiteSpace(textBox2.Text))
                {
                    var cv = dataGrid1.ItemsSource as CollectionView;
                    if (cv != null)
                    {
                        cv.GroupDescriptions.Clear();
                        cv.GroupDescriptions.Add(new PropertyGroupDescription(textBox2.Text));
                    }
    
                }
            }
    
            private void button1_Click(object sender, RoutedEventArgs e)
            {
    
                DataTable dt = new DataTable();
    
    
                if (textBox1.Text.Equals("customers", StringComparison.InvariantCultureIgnoreCase))
                {
                    Data.Northwind_2007DataSetTableAdapters.CustomersTableAdapter c = new Data.Northwind_2007DataSetTableAdapters.CustomersTableAdapter();
                    dt = c.GetData();
                }
                else if (textBox1.Text.Equals("employees", StringComparison.InvariantCultureIgnoreCase))
                {
                    Data.Northwind_2007DataSetTableAdapters.EmployeesTableAdapter emp = new Data.Northwind_2007DataSetTableAdapters.EmployeesTableAdapter();
                    dt = emp.GetData();
                }
    
    
                dataGrid1.ItemsSource = (CollectionView)CollectionViewSource.GetDefaultView(dt.DefaultView);
    
            }
        }
    }
