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
    
    namespace DataGridView
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
    
    
                table.ItemsSource = getItemByCategory().DefaultView;
            }
    
            public static DataTable getItemByCategory(int category = 0)
            {
                //ServiceReference.ServiceSoapClient instance = Database.getClient();
                DataTable tabel = new DataTable();
                DataRow linie;
                tabel.Columns.Add(new DataColumn("id", typeof(int)));
                tabel.Columns.Add(new DataColumn("name", typeof(string)));
                
                //tabel.Columns.Add(new DataColumn("price", typeof(int)));
                //tabel.Columns.Add(new DataColumn("inCart", typeof(bool)));
                //ServiceReference.ArrayOfString[] values = instance.getItemsByCategory(category);
    
                List<Foo> values = new List<Foo>();
                for (int i = 0; i < 10; i++)
                {
                    values.Add(new Foo { ID = i, Name = "name " + i });
                }
    
                foreach (var v in values)
                {
                    linie = tabel.NewRow();
                    linie["id"] = v.ID;
                    linie["name"] = v.Name;
                    //linie["price"] = Convert.ToInt32(v[3]);
                    //linie["inCart"] = false;
                    tabel.Rows.Add(linie);
                }
                return tabel;
            }
    
            private void table_Loaded(object sender, RoutedEventArgs e)
            {
                table.Columns[0].Width = 100;
                table.Columns[1].Width = 200;
            }
        }
    
        public class Foo
        {
            public int ID { get; set; }
            public string Name { get; set; }
        }
    
    
    }
