    dtTempGrdBlockForDeviceByRole = Cls_BLOCKS.getDataTable_WriteField();
    grdBlockForDeviceByRole = Cls_BLOCKS.getDataTable_WriteField();            
    for (int x = 0; x < grdBlockForDeviceByRole.Rows.Count; x++)
    {
        CheckBox chk = grdBlockForDeviceByRole.Rows[x].FindControl("ckDelete") as CheckBox;
        string txtD = grdBlockForDeviceByRole.Rows[x].Cells[0].Text;                
        if (chk.Checked)
        {
            dtTempGrdBlockForDeviceByRole.Rows.RemoveAt(x);  
        }                
    }
    grdBlockForDeviceByRole.DataSource = dtTempGrdBlockForDeviceByRole;
    grdBlockForDeviceByRole.DataBind();
