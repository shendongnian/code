    public class DataGridViewCalendarCell : DataGridViewTextBoxCell
    {
        public DataGridViewCalendarCell()
            : base()
        {
            this.Style.Format = "d";    //short date style
        }
    
        public override void InitializeEditingControl(int rowIndex, object initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
        {
            //set the value of the editing control to the current cell value
            base.InitializeEditingControl(rowIndex, initialFormattedValue, dataGridViewCellStyle);
    
            DataGridViewCalendarControl ctl = DataGridView.EditingControl as DataGridViewCalendarControl;
    
            //use default value if Value is null
            if (this.Value == null || this.Value == DBNull.Value)
                ctl.Value = (DateTime) this.DefaultNewRowValue;
            else
                ctl.Value = (DateTime) this.Value;
        }
    
        public override Type EditType
        {
            get
            {
                //return the type of control this cell uses
                return typeof(DataGridViewCalendarControl);
            }
        }
    
        public override Type ValueType
        {
            get
            {
                //return the type of the value that this cell contains
                return typeof(DateTime);
            }
        }
    
        public override object DefaultNewRowValue
        {
            get
            {
                //use today's date as the default value
                return DateTime.Now;
            }
        }
    }
