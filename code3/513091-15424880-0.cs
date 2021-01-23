            Load += delegate
            {
                // remove default [x] image for data DataGridViewImageColumn columns
                foreach (var column in dataGridView1.Columns)
                {
                    if (column is DataGridViewImageColumn)
                        (column as DataGridViewImageColumn).DefaultCellStyle.NullValue = null;
                }
            };
