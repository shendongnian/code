    public partial class UIisNotData : Window
        {
            public ObservableCollection<Owner> Owners { get; set; }
            public ObservableCollection<string> Kinds { get; set; }
            public ObservableCollection<Dog> Dogs { get; set; } 
    
            public UIisNotData()
            {
                InitializeComponent();
    
                Owners = new ObservableCollection<Owner>
                    {
                        new Owner() {Name = "Jack"},
                        new Owner() {Name = "Mike"},
                        new Owner() {Name = "Kirk"},
                        new Owner() {Name = "John"},
                    };
    
                Kinds = new ObservableCollection<string>
                    {
                        "Affenpinscher",
                        "Afghan Hound",
                        "Airedale Terrier",
                        "Akita"
                        //.. All the rest of dog Breeds taken from http://www.petmd.com/dog/breeds?breed_list=az#.UVsQKpPcmQo
                    };
    
                Dogs = new ObservableCollection<Dog>
                    {
                        new Dog() {Name = "Bobby", Kind = Kinds[0], Owner = Owners[0]},
                        new Dog() {Name = "Fido", Kind = Kinds[1], Owner = Owners[1]},
                        new Dog() {Name = "Toby", Kind = Kinds[2], Owner = Owners[2]}
                    };
    
                DataContext = this;
            }
    
            private void AddOwner(object sender, RoutedEventArgs e)
            {
                Owners.Add(new Owner(){Name = "New Owner"});
            }
        }
