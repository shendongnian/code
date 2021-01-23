    private void dataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
    {
      if (dataGridView.Rows.Count > 0)
       {
         Double dobTotal = 0.00;
         if (dataGridView.Columns["colAmountPaid"].Name.ToString().Equals("colAmountPaid"))
          {
           for (int i = 0; i < dataGridView.Rows.Count; i++)
           {
            dobTotal += Double.Parse(dataGridView["colAmountPaid",i].EditedFormattedValue.ToString());
           }
           txtTotal.Text = dobTotal.ToString();
          }
         }
       }
