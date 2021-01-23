    public class DropDownCellWithTextBox : DataGridViewComboBoxCell
    {
       ContextMenuStrip dropDownList;
       ToolStripTextBox txtBox;
       DataGridView dgv;
 
       public DropDownCellWithTextBox(DataGridView _dgv)
       {
           dgv = _dgv;
 
           dropDownList = new ContextMenuStrip();
 
           txtBox = new ToolStripTextBox();
           txtBox.BorderStyle = BorderStyle.FixedSingle;
           txtBox.KeyDown += txtBox_KeyDown;
       
           dropDownList.Items.Add(txtBox);
       }
 
   public override void InitializeEditingControl(int rowIndex,
   object initialFormattedVaulue, DataGridViewCellStyle dataGridViewCellStyle)
   {
       base.InitializeEditingControl(rowIndex,initialFormattedValue,dataGridViewCellStyle);
 
            ContextMenuStrip cms = DataGridView.EditingControl as ContextMenuStrip;
   }
 
    protected override void OnMouseClick(DataGridViewCellMouseEventArgs e)
    {
        //base.OnMouseClick(e)
        dropDownList.Size = dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Size;
        dropDownList.Show(dgv.PointToScreen(new Point(e.X, e.Y));
    }
    
    private void txtBx_KeyDown(object sender, KeyEventArgs e)
    {
        ToolStripTextBox txt = (ToolStripTextBox)sender;
        if (txt.Text == "")
            return;
           
        if (e.KeyCode == Keys.Enter)
        {
            ToolStripMenuItem tsmi = new ToolStripMenuItem(txt.Text);
            tsmi.Name = txt.Text;
 
            if (!dropDownList.Items.ContainsKey(tsmi.Name))
            {
                 dropDownList.Items.Add(tsmi);
                 txt.Text = "";
            }
        }
    }
}
