        public override void InitializeEditingControl(int rowIndex, object initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
        {
           //... 
           //DateTime dt = (DateTime)this.Value;
           DateTime dt = (DateTime)this.GetValue(rowIndex);
           //...
        }
