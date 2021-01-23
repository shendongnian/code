        public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public long SelectedValue { get { return selectedValue; } set { selectedValue = value; Notify("SelectedValue"); } }
        private long selectedValue;
        private Dictionary<long, string> myDictionary;
        public Dictionary<long, string> MyDictionary { get { return myDictionary; } set { myDictionary = value; Notify("MyDictionary"); } }
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            ComboBoxBinding();
            MyDictionary = new Dictionary<long, string>() { { 1, "abc" }, { 2, "xyz" }, { 3, "pqr" } };
            SelectedValue = 2;
            
        }
        public void ComboBoxBinding()
        {
            Control control = new ComboBox();
            comboBoxControl = (ComboBox)control;
            comboBoxControl.SetBinding(ComboBox.ItemsSourceProperty, createFieldBinding("MyDictionary"));
            comboBoxControl.DisplayMemberPath = "Value";
            comboBoxControl.SelectedValuePath = "Key";
           comboBoxControl.SetBinding(ComboBox.SelectedValueProperty, createFieldBinding("SelectedValue"));
        }
        private Binding createFieldBinding(string fieldName)
        {
            Binding binding = new Binding(fieldName);
            binding.Source = this.DataContext;
            binding.UpdateSourceTrigger = System.Windows.Data.UpdateSourceTrigger.PropertyChanged;
            return binding;
        }
        private void Notify(string propName)
        {
            if(PropertyChanged!=null)
                PropertyChanged(this,new PropertyChangedEventArgs(propName));
        }
        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
    }
