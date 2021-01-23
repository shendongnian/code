        public string SortOrder;
        public string ItemSorted;
        private void LSTHistory_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            DataTable TempTable = new DataTable();
            for (int i = 0; i < LSTHistory.Columns.Count; i++)
            {
                TempTable.Columns.Add(LSTHistory.Columns[i].Text);
            }
            foreach (ListViewItem Item in LSTHistory.Items)
            {
                DataRow iRow = TempTable.NewRow();
                iRow[0] = Item.Text;
                iRow[1] = Item.SubItems[1].Text;
                TempTable.Rows.Add(iRow);
            }
            if (SortOrder == string.Empty || SortOrder == "ASC") SortOrder = "DESC";
            else SortOrder = "ASC";
            if (e.Column == COLTime.Index)
            {
                ItemSorted = COLTime.Text;
            }
            else
            {
                ItemSorted = COLURL.Text;
            }
            DataView OldView = TempTable.DefaultView;
            OldView.Sort = ItemSorted + " " + SortOrder;
            DataTable SortedTable = OldView.ToTable();
            LSTHistory.Items.Clear();
            foreach (DataRow iRow in SortedTable.Rows)
            {
                LSTHistory.Items.Add(iRow[0].ToString()).SubItems.Add(iRow[1].ToString());
            }
        }
