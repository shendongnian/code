    private SortOrder _sortDirection;
        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e) {
            if (e.ColumnIndex == 0) {
                string sort = string.Empty;
                switch (_sortDirection) {
                    case SortOrder.None:
                        _sortDirection = SortOrder.Ascending;
                        sort = "asc";
                        break;
                    case SortOrder.Ascending:
                        _sortDirection = SortOrder.Descending;
                        sort = "desc";
                        break;
                    case SortOrder.Descending:
                        _sortDirection = SortOrder.None;
                        sort = string.Empty;
                        break;
                }
                dataGridView1.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = _sortDirection;
                if (!string.IsNullOrEmpty(sort)) {
                    bindingSource1.Sort = "DateOfBirth " + sort;
                } else {
                    bindingSource1.RemoveSort();
                }
            }
        }
