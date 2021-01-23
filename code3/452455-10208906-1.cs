    private void oOpcGroup_DataChange(int TransactionID, int NumItems, ref Array ClientHandles, ref Array ItemValues, ref Array Qualities, ref Array TimeStamps)  
    {
            
        for (int i = 0; i < NumItems; i++)
        {
            var obj = ItemValues.GetValue(i);
            if (obj != null && !obj.GetType().IsArray)
            {
                txtSubValue.Text = obj.ToString();
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Data type return error, returned array, expected single item", "Data Change Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
