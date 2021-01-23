    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Linq;
    
    namespace ComboBoxWrapperSample
    {
        public partial class SampleViewModel : INotifyPropertyChanged
        {
    
            // SelectedWrappedItem- This property stores selected wrapped item
            public ComboBoxNullableItemWrapper<Person> _SelectedWrappedItem { get; set; }
    
            public ComboBoxNullableItemWrapper<Person> SelectedWrappedItem
            {
                get { return _SelectedWrappedItem; }
                set
                {
                    _SelectedWrappedItem = value;
                    OnPropertyChanged("SelectedWrappedItem");
                }
            }
    
            // ListOfPersons - Collection to be injected into ComboBox.ItemsSource property
            public ObservableCollection<ComboBoxNullableItemWrapper<Person>> ListOfPersons { get; set; }
    
            public SampleViewModel()
            {
    
                // Setup a regular items collection
                var person1 = new Person() { Name = "Foo", Age = 31 };
                var person2 = new Person() { Name = "Bar", Age = 42 };
    
                List<Person> RegularList = new List<Person>();
                RegularList.Add(person1);
                RegularList.Add(person2);
    
                // Convert regular collection into a wrapped collection
                ListOfPersons = new ObservableCollection<ComboBoxNullableItemWrapper<Person>>();
                ListOfPersons.Add(new ComboBoxNullableItemWrapper<Person>(null));
                RegularList.ForEach(x => ListOfPersons.Add(new ComboBoxNullableItemWrapper<Person>(x)));
    
                // Set UserSelectedItem so it targes null item
                this.SelectedWrappedItem = ListOfPersons.Single(x => x.Value ==null);
    
            }
    
            // INotifyPropertyChanged related stuff
            public event PropertyChangedEventHandler PropertyChanged;
    
            protected void OnPropertyChanged(string name)
            {
                PropertyChangedEventHandler handler = PropertyChanged;
                if (handler != null)
                {
                    handler(this, new PropertyChangedEventArgs(name));
                }
            }
        }
    }
