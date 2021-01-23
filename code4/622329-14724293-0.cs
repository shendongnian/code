    public class MyModel : INotifyPropertyChanged
    {
        public DateTime? DateTimeFilter
        {
            get { return dateTimeFilter; }
            set
            {
                if (dateTimeFilter != value)
                {
                    dateTimeFilter = value;
                    OnPropertyChanged("DateTimeFilter");
                }
            }
        }
        private DateTime? dateTimeFilter;        
        // INotifyPropertyChanged implementation is omitted
    }
    public partial class Form1 : Form
    {
        private readonly MyModel model;
        public Form1()
        {
            InitializeComponent();
            model = new MyModel();
            dateTimePicker1.DataBindings.Add("Value", model, "DateTimeFilter", true, DataSourceUpdateMode.OnPropertyChanged, DateTime.Now);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(model.DateTimeFilter.HasValue ? string.Format("User has selected '{0}'.", model.DateTimeFilter) : "User hasn't selected anything.");
        }
        private void button2_Click(object sender, EventArgs e)
        {
            // here's the data binding magic: our model's property becomes null, 
            // and datetimepicker's value becomes DateTime.Now, as it was initially set
            model.DateTimeFilter = null;
        }
    }
