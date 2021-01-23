    public class ColumnCheckBox:CheckBox
    {
        public int ColumnIndex;
    }
    void columnCheckBox1_CheckedChanged(object sender, EventArgs e)
    {
        int columnIndex = ((ColumnCheckBox)sender).ColumnIndex;
    }
