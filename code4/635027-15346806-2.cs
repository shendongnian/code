    private void btnHist_Click(object sender, EventArgs e)
        {
            DataSet tempDataSet = new DataSet();
            tempDataSet = userData;
            tempDataSet.Tables[0].Columns.RemoveAt(1); //remove columns 0 and 1 for display purposes
            tempDataSet.Tables[0].Columns.RemoveAt(0);
            HistForm hForm = new HistForm(tempDataSet);
            hForm.Show();
        }
