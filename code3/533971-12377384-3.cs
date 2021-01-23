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
    using System.ComponentModel;
    
    namespace WpfDataGridWithDataTable
    {
       
        public partial class Window1 : Window
        {
            private ListArticles myList;
            public Window1()
            {
                InitializeComponent();
    
    
    
                myList = new ListArticles();
    
    
                this.DataContext = myList;
    
            }
    
            private void btnAdd_Click(object sender, RoutedEventArgs e)
            {
                myList.Add(new Article());
            }
    
            private void btnDelete_Click(object sender, RoutedEventArgs e)
            {
                myList.Remove(this.dataGrid1.SelectedItem as Article);
            }
    
            private void GroupButton_Click(object sender, RoutedEventArgs e)
            {
                ICollectionView cvsListArticles = CollectionViewSource.GetDefaultView(dataGrid1.ItemsSource);
                if (cvsListArticles != null && cvsListArticles.CanGroup == true)
                {
                    cvsListArticles.GroupDescriptions.Clear();
                    cvsListArticles.GroupDescriptions.Add(new PropertyGroupDescription("ModelName"));
                }
            }
    
           
        }
    }
