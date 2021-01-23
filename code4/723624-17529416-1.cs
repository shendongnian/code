    public class MainViewModel
    {
        public ArrayList Options { get; set; }
        public MainViewModel()
        {
            Options = new ArrayList();
            Options.Add(new TextProperty());
            Options.Add(new BoolProperty());
        }
    }
    public class TextProperty
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public TextProperty()
        {
            Name = "Name";
            Value = "Default";
        }
    }
    public class BoolProperty
    {
        public string Name { get; set; }
        public bool Value { get; set; }
        public BoolProperty()
        {
            Name = "IsEnabled";
            Value = true;
        }
    }
