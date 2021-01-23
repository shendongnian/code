       private void dataGridViewCrossRef_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 25)
            {
                //Find primaykey or something unique from your dataTable   
                DataRow[] Rows = dataTable.Select("Id = '" + dataGridViewCrossRef[0, e.RowIndex].EditedFormattedValue.ToString() + "'");
                Rows[0]["NameOfColumnHasCheckBox"] = !bool.Parse(Rows[0]["NameOfColumnHasCheckBox"].ToString());
            }
        }
