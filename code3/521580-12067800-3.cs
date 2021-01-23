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
    using System.Collections.ObjectModel;
    using RadarControls;
    namespace RadarStudio
    {
        /// <summary>
        /// Interaction logic for Users.xaml
        /// </summary>
        public partial class Users : Window
        {
            RadarDataGrid rg = new RadarDataGrid();//Object of user control
            List<UserList> List = new List<UserList>();// It will be your item source
            UserList ListItem;
            public Users()
            {
                InitializeComponent();
                //this.DataContext = this;
                ListItem = new UserList();
                ListItem.UserName = "dhaval";//Adding First Item
                List.Add(ListItem);
                ListItem = new UserList();
                ListItem.UserName = "ravinder";//Adding Second
                List.Add(ListItem);
                rg.RadarGrid.ItemsSource = List;//Assigned Itemsource
    
                Dggrid.Children.Add(rg);
            }
        }
    /*This Class is need to store user information, you can include users additional details 
    (if needed) by creating corresponding Properties*/
        public class UserList
        {
            string userName;
            public string UserName
            {
                get { return userName; }
                set { userName = value; }
            }
        }
    }
