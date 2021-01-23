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
    using System.Windows.Shapes;
    
    namespace KontaktInfo
    {
        /// <summary>
        /// Interaction logic for CreateContact.xaml
        /// </summary>
        public partial class CreateContact : Window
        {
            public CreateContact()
            {
                InitializeComponent();
            }
    
            private void cmdOk_Click(object sender, RoutedEventArgs e)
            {
                MainWindow m = new MainWindow();
                m.name = txtName.Text;
                m.age = txtAge.Text;
                m.birthDate = dpBirthdate.Text;
                m.ShowContacts();
                
                
    
            }
        }
    }
