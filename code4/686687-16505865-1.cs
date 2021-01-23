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
    
    namespace KontaktInfo
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public string name;
            public string age;
            public string birthDate;
    
            public MainWindow()
            {
                InitializeComponent();   
            }
    
            private void cmdCreateContact_Click(object sender, RoutedEventArgs e)
            {
                CreateContact cc = new CreateContact();
                cc.ShowDialog();
            }
    
            public void ShowContacts()
            {
                try
                {
                    dgContacts.ItemsSource = LoadContactData();
                }
                catch (Exception e)
                {
                    MessageBox.Show("" + e);
                }
            }
    
            private List<ContactData> LoadContactData()
            {
                List<ContactData> list = new List<ContactData>();
                list.Add(new ContactData()
                {
                    Name = name,
                    Age = age,
                    BirthDate = birthDate
                });
                
                return list;
            }
    
        }
    
    public class ContactData
        {
            public string Name { get; set; }
            public string Age { get; set; }
            public string BirthDate { get; set; }
        }
    }
    
