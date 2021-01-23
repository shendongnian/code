    private void button3_Click(object sender, EventArgs e) {
        //clear balance
        projectpizzaDataSet ds = new projectpizzaDataSet();
        projectpizzaDataSetTableAdapters.balanceTableAdapter daCust = new projectpizzaDataSetTableAdapters.balanceTableAdapter();
        while (dataGridView1.Rows.Count > 0 {
            dataGridView1.Rows.RemoveAt(0);
        }
        this.balanceTableAdapter.Update(projectpizzaDataSet.balance);
    }
