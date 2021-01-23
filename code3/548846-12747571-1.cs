    using System.Collections.ObjectModel;
    namespace WpfApplication18
    {
        public class PersonVM
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }
        public class SpecificPersonVM : PersonVM
        {
            public byte Age { get; set; }
        }
        public class PersonsVM
        {
            public ObservableCollection<PersonVM> Items { get; private set; }
            public PersonsVM()
            {
                Items = new ObservableCollection<PersonVM>();
            }
        }
        public class SpecificPersonsVM
        {
            public ObservableCollection<SpecificPersonVM> Items { get; private set; }
            public SpecificPersonsVM()
            {
                Items = new ObservableCollection<SpecificPersonVM>();
            }
        }
    }
