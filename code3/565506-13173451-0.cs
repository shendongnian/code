    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var label = new Label();
            label.Content = "Click me!";
            label.Name = "clickMe";
            this.Content = label;
            var cmb = new ComboBox();
            cmb.Name = "combobox1";
            cmb.Items.Add("Test1");
            cmb.Items.Add("Test2");
            cmb.Items.Add("Test3");
            cmb.SelectionChanged += new SelectionChangedEventHandler(cmb_SelectionChanged);
            var menu = new ContextMenu();
            menu.Name = "contextmenu";
            menu.Items.Add(cmb);
            label.ContextMenu = menu;
        }
        private void cmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var cmb = (ComboBox)sender;
            var contextmenu = (ContextMenu)cmb.Parent;
            var label = (Label)contextmenu.PlacementTarget;
            MessageBox.Show("Combobox: " + cmb.Name + Environment.NewLine +
                            "Contextmenu: " + contextmenu.Name + Environment.NewLine +
                            "Label: " + label.Name);
        }
    }
