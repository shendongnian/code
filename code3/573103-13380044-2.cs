    private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
        if (e.ColumnIndex == 4)
        {
             for (int intCount = 0; intCount < dsMainDoctors.Tables[0].Rows.Count; intCount++)
             {
                 if (e.Value.ToString().Equals(dsMainDoctors.Tables[0].Rows[intCount][0].ToString()))
                 {
                      e.Value = txt.Value = dsMainDoctors.Tables[0].Rows[intCount][1].ToString();
                 }
             }
         }
    }
