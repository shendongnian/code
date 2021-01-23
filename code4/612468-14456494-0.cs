    int i = 0;
    if(dgv.SelectedRows.Count > 0)
    {
    while (i < dgv.Columns.Count)
    {
        if (dgv.SelectedRows[0].Cells[i].Value != null)
            Variables.addModArray[i] = dgv.SelectedRows[0].Cells[i].Value.ToString(); 
        i++;
    }
    }
