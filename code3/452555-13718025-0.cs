    `enter code here`In the control event Just write this code
    
    {
     for (int i = 0; i < gvVndInvoiceDevExp.VisibleRowCount ; i++)
                {
                    GridViewDataColumn col1 = gvVndInvoiceDevExp.Columns[0] as GridViewDataColumn;
                    GridViewDataColumn col2 = gvVndInvoiceDevExp.Columns[8] as GridViewDataColumn;
                    CheckBox chk = gvVndInvoiceDevExp.FindRowCellTemplateControl(i, col1, "chk") as CheckBox;
                    ASPxCheckBox chkIsVal = gvVndInvoiceDevExp.FindRowCellTemplateControl(i, col2, "chkIsVal") as ASPxCheckBox;
                  
                    if (chk.Checked == true)
                    {
                        chkIsVal.Enabled = true;
                      
                    }
                    else
                    {
                        chkIsVal.Enabled = false;
                      
                    }
                    
                }
    }
