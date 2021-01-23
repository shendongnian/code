    //I changed i=2 to i = 1 to get first column header
    for (int i = 1; i <= dgvCreditLimitTransaction.ColumnCount; i++)
    {
    	worksheet.Cells[1, i] = dgvCreditLimitTransaction.Columns[i - 1].HeaderText;
    	
        if (dgvCreditLimitTransaction.Columns[i - 1].HeaderText == "LC Number")
    	{
    		hdinvdate = i - 1;
    	}
    }
    //changed i = 0 to i = 1 to remove the first row, if you wish to keep the first row set i = 0
    for (int i = 0; i < dgvCreditLimitTransaction.RowCount; i++)
    {
        //change j = 1 to j = 0 so that you get 1st columns data
    	for (int j = 0; j < dgvCreditLimitTransaction.ColumnCount; j++)
    	{
    		if (dgvCreditLimitTransaction.Rows[i].Cells[j].Value != null)
    		{
    			if (j == hdinvdate)
    			{
    
    				DateTime tempinvdt = Convert.ToDateTime(dgvCreditLimitTransaction.Rows[i].Cells[j].Value);
    
    				worksheet.Cells[i + 2, j + 1] = tempinvdt.ToString("MM/dd/yyyy");
    
    			}
    			else
    			{
    				worksheet.Cells[i + 2, j + 1] = dgvCreditLimitTransaction.Rows[i].Cells[j].Value.ToString();
    			}
    
    		}
    	}
    }
    // Exit from the application 
    //           app.Quit();
    }
    else
    {
    MessageBox.Show("Please select Data");
    }
