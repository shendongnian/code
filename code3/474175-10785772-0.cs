    Form_Load()
    {
    	DataGridViewCellStyle AStyle = new DataGridViewCellStyle();
    	AStyle.BackColor = Color.BlueViolet;
    
    	blah...blah...blah..
    }
    private void MyDataGrid1_RowLeave(Object Sender, DataGridViewCellEventArgs e)
    {
    	for (int I1 = 0; I1 < dataGrid1.Columns.Count - 1; I1++)
            {
            	if (I1 == 3 || I1 == 5)
                    {
                        dataGrid1.CurrentRow.Cells[I1].Style = AStyle;   
                    }
    
    	}
    
    }
