    public class MyDataGridView:DataGridView
    {
        public ComboBox MyComboBox { get; set; } //in case you had no other way to refer to it
        
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if((keyData == Keys.Enter) && (MyComboBox.Focused))
            {
                //commit choice logic
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
