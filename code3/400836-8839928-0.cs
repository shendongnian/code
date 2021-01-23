         public partial class DTP : Form
         {
            DateTime lastSelectedValue;
            public DTP()
            {
             InitializeComponent();
 
             lastSelectedValue = dateTimePicker1.Value;
             dateTimePicker1.ValueChanged += new EventHandler(dateTimePicker1_ValueChanged);
             }
        void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DialogResult di =  MessageBox.Show("Change " + lastSelectedValue.ToString() + " to " + dateTimePicker1.Value.ToString(), "?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
            
            if(di== System.Windows.Forms.DialogResult.OK)
            {
                SetSqlDateTimeValue( dateTimePicker1.Value );
                lastSelectedValue =  dateTimePicker1.Value;
            }
            else
            {
                //Setting back the dtp to the old value
                dateTimePicker1.Value = lastSelectedValue;
            }
        }
        private void SetSqlDateTimeValue(DateTime dateTime)
        {
            throw new NotImplementedException();
        }
    }
