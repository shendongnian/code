    public partial class ManiacalBindingForm : Form, INotifyPropertyChanged {
        public ManiacalBindingForm() {
            InitializeComponent();
            this.button.DataBindings.Add("Enabled", this, "ManiacalThreshold", true, DataSourceUpdateMode.OnPropertyChanged);
            this.trackBar.ValueChanged += (s, e) => {
                this.Text = string.Format("ManiacalBindingForm: {0}", this.trackBar.Value);
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("ManiacalThreshold"));
            };
        }
        public bool ManiacalThreshold {
            get { return this.trackBar.Value > 50; }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        ...
    }
