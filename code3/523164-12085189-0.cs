	private void analyzeButton_Click(object sender, EventArgs e)
	{
		listView1.Items.Clear();
		//I just add this line 
		listviewItem_Counter = 0;  // -> this integer needs to be set as zero because evrytime the analyze button be click it will be use, so it needs to be fresh again!
		
		DataTable dtXLS = loadXLS(xls_path);
		WordsToRedactFunc(pdfRT, visfRT, dtXLS, listView1);
		MessageBox.Show("Processing done!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
	}
