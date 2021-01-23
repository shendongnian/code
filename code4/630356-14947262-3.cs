    public partial class EmployeeCtrl : UserControl
    {
        public static readonly DependencyProperty EmpNameProperty = 
           DependencyProperty.Register("EmpName", typeof(string),
           typeof(EmployeeCtrl), new FrameworkPropertyMetadata(null));
        public static readonly DependencyProperty SurnameProperty = 
           DependencyProperty.Register("Surname", typeof(string),
           typeof(EmployeeCtrl), new FrameworkPropertyMetadata(null));
        public EmployeeCtrl()
        {
            this.InitializeComponent();
        } 
        public string EmpName
        {
           get { return (string)GetValue(EmpNameProperty); }
           set { SetValue(EmpNameProperty, value); }
        }
        public string Surname
        {
           get { return (string)GetValue(SurnameProperty); }
           set { SetValue(SurnameProperty, value); }
        }
    }
