     private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
            {
                if (e.ColumnIndex == 0)
                {
                    //Find primaykey from dataTable   
                    DataRow[] Rows = dataTable.Select("Id = '" + dataGridView1[1, e.RowIndex].EditedFormattedValue.ToString() + "'");
                    Rows[0]["CheckBoxes"] = !bool.Parse(Rows[0]["CheckBoxes"].ToString());
                }
            }
