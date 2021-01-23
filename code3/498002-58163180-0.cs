	private void button1_Click(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
	{
		GridView view = sender as GridView;  
		view.SetRowCellValue(e.RowHandle, view.Columns[0], 1);  
		view.SetRowCellValue(e.RowHandle, view.Columns[1], 2);  
		view.SetRowCellValue(e.RowHandle, view.Columns[2], 3);
	}
