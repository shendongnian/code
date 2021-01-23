    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            TestItems = new ObservableCollection<Test>();
            InitializeComponent();
      
            for (int i = 0; i < 5; i++)
                TestItems.Add(InitTest(i));
        }
        public ObservableCollection<Test> TestItems { get; set; }
        private Test InitTest(int index)
        {
            Test test = new Test();
            test.Name  = "Test" + index.ToString();
            test.Test2Items =  new ObservableCollection<Test2>();
            for (int i = 0; i <= index; i++)
            {
                Test2 test2 = new Test2();
                test2.Label = test.Name + "_label" + i.ToString();
                test.Test2Items.Add(test2);
            }
            return test;
        }
    }
    public class Test
    {
        public string Name { get; set; }
        public ObservableCollection<Test2> Test2Items { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }
    public class Test2
    {
        public string Label { get; set; }
        public override string ToString()
        {
            return Label;
        }
    }
