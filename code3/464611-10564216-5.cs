    public partial class CalendarForm : Form {
        public event DateRangeEventHandler DateSelected;
        public CalendarForm() {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            monthCalendar1.Resize += delegate {
                this.ClientSize = monthCalendar1.Size;
            };
            monthCalendar1.DateSelected += monthCalendar1_DateSelected;
        }
        void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e) {
            if (DateSelected != null) DateSelected(this, e);
            this.DialogResult = DialogResult.OK;
        }
    }
