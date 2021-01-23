    public class DataGridViewCalendarControl : DateTimePicker, IDataGridViewEditingControl
        {
            private DataGridView dataGridView;
            private bool hasValueChanged = false;
            int rowIndex;
    
            public DataGridViewCalendarControl()
            {
                this.Format = DateTimePickerFormat.Short;
            }
    
            protected override void OnValueChanged(EventArgs eventargs)
            {
                //Notify the DataGridView that the value has changed
                hasValueChanged = true;
                this.EditingControlDataGridView.NotifyCurrentCellDirty(true);
    
                base.OnValueChanged(eventargs);
            }
    
            #region IDataGridViewEditingControl Members
    
            public void ApplyCellStyleToEditingControl(DataGridViewCellStyle dataGridViewCellStyle)
            {
                this.Font = dataGridViewCellStyle.Font;
                this.CalendarForeColor = dataGridViewCellStyle.ForeColor;
                this.CalendarMonthBackground = dataGridViewCellStyle.BackColor;
            }
    
            public DataGridView EditingControlDataGridView
            {
                get { return dataGridView; }
                set { dataGridView = value; }
            }
    
            public object EditingControlFormattedValue
            {
                get { return this.Value.ToShortDateString(); }
                set
                {
                    if (value is String)
                        try
                        {
                            this.Value = DateTime.Parse((String) value);
                        }
                        catch
                        {
                            this.Value = DateTime.Now;
                        }
                }
            }
    
            public int EditingControlRowIndex
            {
                get { return rowIndex; }
                set { rowIndex = value; }
            }
    
            public bool EditingControlValueChanged
            {
                get { return hasValueChanged; }
                set { hasValueChanged = value; }
            }
    
            public bool EditingControlWantsInputKey(Keys keyData, bool dataGridViewWantsInputKey)
            {
                //the DateTimePicker needs to handle the keys
                switch (keyData & Keys.KeyCode)
                {
                    case Keys.Left:
                    case Keys.Right:
                    case Keys.Up:
                    case Keys.Down:
                    case Keys.Home:
                    case Keys.End:
                    case Keys.PageUp:
                    case Keys.PageDown:
                        return true;
    
                    default:
                        return !dataGridViewWantsInputKey;
                }
            }
    
            public Cursor EditingPanelCursor
            {
                get { return base.Cursor; }
            }
    
            public object GetEditingControlFormattedValue(DataGridViewDataErrorContexts context)
            {
                return EditingControlFormattedValue;
            }
    
            public void PrepareEditingControlForEdit(bool selectAll)
            {
                //nowt needs doing...
            }
    
            public bool RepositionEditingControlOnValueChange
            {
                get { return false; }
            }
