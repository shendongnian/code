    private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
      var selRow = this.yourDataGridView.SelectedRows.FirstOrDefault();
      // or
      // var selRow = this.yourDataGridView.Rows[e.RowIndex];
      if (selRow != null) {
        var selRowData = selRow.DataBoundItem as waterDataSet.DEMRow;
        if (selRowData != null) {
          frmWater WaterForm = new frmWater(this);
          WaterForm.LoadWaterAcct(selRowData.WATER_ACCOUNT, null);
          WaterForm.Show();
        }
      }
    }
