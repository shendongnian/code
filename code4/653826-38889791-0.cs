                DataView dv = datatable.DefaultView;
                StringBuilder sb = new StringBuilder();
                foreach (DataColumn column in dv.Table.Columns)
                {
                    sb.AppendFormat("[{0}] Like '%{1}%' OR ", column.ColumnName, "FilterString");
                }
                sb.Remove(sb.Length - 3, 3);
                dv.RowFilter = sb.ToString();
                dgvReports.ItemsSource = dv;
                dgvReports.Items.Refresh();
