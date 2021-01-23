    public class ViewModel : ViewModelBase // INPC implementation
    {
        public String Name
        {
            get { return name; }
            set
            {
                if (name != value)
                {
                    name = value;
                    OnPropertyChanged("Name");
                }
            }
        }
        private String name;
    }
    public partial class Form1 : Form
    {
        private readonly ViewModel viewModel;
        public Form1()
        {
            InitializeComponent();
            var binding = new System.Windows.Data.Binding("Name");
            binding.Source = new ViewModel { Name = "Lorem ipsum dolor sit amet, consectetur adipiscing elit." };
            // this will update data source every time, when TextBox.Text will changed
            binding.UpdateSourceTrigger = System.Windows.Data.UpdateSourceTrigger.PropertyChanged;
            var textBox = new System.Windows.Controls.TextBox();
            textBox.SetBinding(System.Windows.Controls.TextBox.TextProperty, binding);
            elementHost1.Child = textBox;
        }
    }
