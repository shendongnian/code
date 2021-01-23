    public class Test : DependencyObject
    {
        public static readonly DependencyProperty FilterStringProperty =
            DependencyProperty.Register("Property", typeof(string),
            typeof(Test), new UIPropertyMetadata("Success"));
        public string Property
        {
            get { return (string)GetValue(FilterStringProperty); }
            set { SetValue(FilterStringProperty, value); }
        }
        public static Test Instance { get; private set; }
        static Test()
        {
           
        }
        public void Check()
        {
            var prop = new PropertyPath(this.GetType().GetProperty("Property"));
            var binding = new Binding();
            binding.Source = this;
            //binding.Source = typeof(Test); //-- same thing
            binding.Path = prop;
        }
        public static void DoTest()
        {
            
            Instance = new Test();
            new Test().Check();
        }
    }
