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
    using System.ComponentModel;
    using System.Collections.ObjectModel;
    
    namespace WpfApplication1
    {
        /// <summary>
        /// Interaction logic for TestSettings.xaml
        /// </summary>
        public partial class TestSettings : Window
        {
    
            public ObservableCollection<CheckedListItem<Customer>> Customers
            {
                get;
                set;
            }
    
    
            public class Customer
            {
                public string CustomerName { get; set; }
            }
    
            public TestSettings()
            {
                InitializeComponent();
    
                if (Properties.Settings.Default.Customers == null)
                {
                    Properties.Settings.Default.Customers = new ObservableCollection<CheckedListItem<Customer>>
                    { 
                            new CheckedListItem<Customer>(new Customer() { CustomerName = "Kelly Smith" }),
                            new CheckedListItem<Customer>(new Customer() { CustomerName = "Joe Brown" }),
                            new CheckedListItem<Customer>(new Customer() { CustomerName = "Herb Dean" }),
                            new CheckedListItem<Customer>(new Customer() { CustomerName = "fg4" }),
                            new CheckedListItem<Customer>(new Customer() { CustomerName = "fg5" }),
                            new CheckedListItem<Customer>(new Customer() { CustomerName = "fg6" }),
                            new CheckedListItem<Customer>(new Customer() { CustomerName = "fg7" }),
                            new CheckedListItem<Customer>(new Customer() { CustomerName = "fg8" }),
                            new CheckedListItem<Customer>(new Customer() { CustomerName = "fg9" }),
                            new CheckedListItem<Customer>(new Customer() { CustomerName = "fg10" }),
                            new CheckedListItem<Customer>(new Customer() { CustomerName = "fg11" }),
                            new CheckedListItem<Customer>(new Customer() { CustomerName = "fg12" }),
                            new CheckedListItem<Customer>(new Customer() { CustomerName = "fg13" }),
                            new CheckedListItem<Customer>(new Customer() { CustomerName = "fg14" })
    
                    };
                    Properties.Settings.Default.Save();
    
                }
                else
                {
                    //var a = Properties.Settings.Default.Customers;
                    //Customers = ObservableCollection<CheckedListItem<>>;
    
                }
            }
    
            public class CheckedListItem<T> : INotifyPropertyChanged
            {
                public event PropertyChangedEventHandler PropertyChanged;
    
                private bool isChecked;
                private T item;
    
                public CheckedListItem()
                { }
    
                public CheckedListItem(T item, bool isChecked = false)
                {
                    this.item = item;
                    this.isChecked = isChecked;
                }
    
                public T Item
                {
                    get { return item; }
                    set
                    {
                        item = value;
                        if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("Item"));
                    }
                }
    
    
                public bool IsChecked
                {
                    get { return isChecked; }
                    set
                    {
                        isChecked = value;
                        if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("IsChecked"));
                    }
                }
            }
    
            private void Window_Closing(object sender, CancelEventArgs e)
            {
                Properties.Settings.Default.Save();
            }
        }
    }
