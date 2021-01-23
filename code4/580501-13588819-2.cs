    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
             InitializeComponent();
             // anything else you want to do here
        }
        public TimeSpan GetSelectedTimeSpan()
        {
           return new TimeSpan((int)numericUpDown1.Value, (int)numericUpDown2.Value, 0, 0);
        }
    }
