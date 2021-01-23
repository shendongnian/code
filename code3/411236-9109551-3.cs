    namespace DataGridTest
    {
        using System.Collections.Generic;
        using System.Collections.ObjectModel;
        using System.ComponentModel;
        using System.Windows;
    
        public partial class MainWindow : Window, INotifyPropertyChanged
        {
            private readonly ICollection<Person> items;
            private Person selectedItem;
    
            public MainWindow()
            {
                InitializeComponent();
    
                this.items = new ObservableCollection<Person>();
                this.items.Add(new Person
                    {
                        FirstName = "Kent",
                        LastName = "Boogaart"
                    });
                this.items.Add(new Person
                {
                    FirstName = "Tempany",
                    LastName = "Boogaart"
                });
    
                this.DataContext = this;
            }
    
            public ICollection<Person> Items
            {
                get { return this.items; }
            }
    
            public Person SelectedItem
            {
                get { return this.selectedItem; }
                set
                {
                    this.selectedItem = value;
                    this.OnPropertyChanged("SelectedItem");
                }
            }
    
            private void OnPropertyChanged(string propertyName)
            {
                var handler = this.PropertyChanged;
    
                if (handler != null)
                {
                    handler(this, new PropertyChangedEventArgs(propertyName));
                }
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
        }
    
        public class Person
        {
            public string FirstName
            {
                get;
                set;
            }
    
            public string LastName
            {
                get;
                set;
            }
    
            public override string ToString()
            {
                return FirstName + " " + LastName;
            }
        }
    }
