    dgv.SelectedRows[0].Cells[i].Value.ToString(); 
    Convert.ToString(dgv.SelectedRows[0].Cells[i].FormattedValue);
    //please try this
    int i = 0;
    if(dgv.SelectedRows.Count > 0)
    {
        while (i < dgv.Columns.Count)
        {
            Variables.addModArray[i] = dgv.SelectedRows[0].Cells[i].FormattedValue; 
            i++;
        }
    }
