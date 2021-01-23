        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            SortOrder ss = dataGridView1.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection;
            string strColumnName = dataGridView1.Columns[e.ColumnIndex].Name;
            PopulateDataGridView(ss, strColumnName);
            //change sorting...
            switch (ss)
            {
                case SortOrder.Ascending:
                    ss = SortOrder.Descending;
                    break;
                case SortOrder.Descending:
                    ss = SortOrder.Ascending;
                    break;
            }
            dataGridView1.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = ss;
            //change column sort mode...
            dataGridView1.Columns[e.ColumnIndex].SortMode = DataGridViewColumnSortMode.Programmatic;
        }
        void PopulateDataGridView(SortOrder ss, string strColumnName)
        {
            label8.Text = "Column: " + strColumnName + " - " + "sort order: " + ss.ToString();
            if (ss == SortOrder.Ascending)
            {
                A_table = "Tmp_Kabat_SfiraTbl";
                SQL = "SELECT Color,Line,Makat,Des,sQty,sNewQty,CountBy_Name,UserName,TermNum,NewQty,Qty from " + A_table + " order by " + strColumnName + " asc";
            }
            else if (ss == SortOrder.Descending)
            {
                A_table = "Tmp_Kabat_SfiraTbl";
                SQL = "SELECT Color,Line,Makat,Des,sQty,sNewQty,CountBy_Name,UserName,TermNum,NewQty,Qty from " + A_table + " order by " + strColumnName + " desc";
            }
            dsView = new DataSet();
            adp = new OleDbDataAdapter(SQL, Conn);
            adp.Fill(dsView, A_table);
            adp.Dispose();
            dataGridView1.DataSource = dsView.Tables[A_table].DefaultView;
            this.dataGridView1.ClearSelection();
        }
