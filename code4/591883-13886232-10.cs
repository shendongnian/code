    using System.Collections.ObjectModel;
    
    namespace WpfApplication
    {
        public class People : ObservableCollection<Person>
        {
            public People()
            {
                for (int i = 0; i < 100; ++i)
                    this.Items.Add(new Person()
                    {
                        Name = "Name " + i,
                        Surname = "Surname " + i,
                        Gender = i % 2 == 0 ? 'M' : 'F'
                    });
            }
        }
    }
