    this.DataContext = new ObservableCollection<Cow>()
                               {
                                   new Cow("Foo"),
                                   new Cow("Bar"),
                                   new Cow("Baz")
                               };
    public class Cow
    {
        public Cow(string name)
        {
            Name = name;
        }
    
        public string Name { get; set; }
    }
