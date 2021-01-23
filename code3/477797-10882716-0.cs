    public class MyClass
    {
        public ObservableCollection<Category> Categories { get; set; }
        public MyClass()
        {
             InitializeComponent();
             ObservableCollection MyTypes = new ObservableCollection();
             MyTypes.Add("type1");
             MyTypes.Add("type2");
             MyTypes.Add("Type3");
             Categories.Add(new Category() { Types = MyTypes });
             //Probably a more elegant way to do this, but hard to say based on information given
             this.DataContext = this;
        }
    }
