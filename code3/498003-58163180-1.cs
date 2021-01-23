	private void button1_Click(object sender, EventArgs e)
	{
		object[] obj = //your row object;
        gridView1.AddNewRow();
		gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[0], obj[0].ToString());  
		gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[1], obj[1].ToString());  
		gridView1.UpdateCurrentRow(); 
	}
