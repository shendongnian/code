    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void TextBox1_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            grid.BindingGroup.CommitEdit();
        }
    }
    public class Indices
    {
        public int ColorIndex { get; set; }
        public string ColorPrefix { get; set; }
        public int GradientIndex { get; set; }
        public string GradientPrefix { get; set; }
    }
    public class ValidateMe : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var bindingGroup = value as BindingGroup;
            var o = bindingGroup.Items[0] as Indices;
            return new ValidationResult(true, null);
        }
    }
