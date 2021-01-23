    public partial class MainWindow : Window
    {
        public class MyClass
        {
            public string Prop1 { get; set; }
            public string Prop2 { get; set; }
            public string Prop3 { get; set; }
        }
        public MainWindow()
        {
            InitializeComponent();
            var objects = new[] 
            { 
                new MyClass { Prop1 = "Object1", Prop2 = "Test1", Prop3 = "Hello" },
                new MyClass { Prop1 = "Object2", Prop2 = "Test2", Prop3 = "Goodbye" },
                new MyClass { Prop1 = "Object3", Prop2 = "Test3", Prop3 = "Welcome" }
            };
            grid.ItemsSource = objects;
        }
        private void cellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            //Only handles cases where the cell contains a TextBox
            var editedTextbox = e.EditingElement as TextBox;
            if (editedTextbox != null)
                MessageBox.Show("Value after edit: " + editedTextbox.Text);
        }
    }
