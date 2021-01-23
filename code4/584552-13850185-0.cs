        Infragistics.Win.UltraWinGrid.UltraGridColumn[] oldSort;
        private void Sort() {
            ultraGrid1.BeforeSortChange += new Infragistics.Win.UltraWinGrid.BeforeSortChangeEventHandler(ultraGrid1_BeforeSortChange);
            ultraGrid1.AfterSortChange += new Infragistics.Win.UltraWinGrid.BandEventHandler(ultraGrid1_AfterSortChange);
        }
        void ultraGrid1_BeforeSortChange(object sender, Infragistics.Win.UltraWinGrid.BeforeSortChangeEventArgs e) {
            oldSort = new Infragistics.Win.UltraWinGrid.UltraGridColumn[e.Band.SortedColumns.Count];
            e.Band.SortedColumns.CopyTo(oldSort, 0);
        }
        void ultraGrid1_AfterSortChange(object sender, Infragistics.Win.UltraWinGrid.BandEventArgs e) {
            for (int i = 0; i < oldSort.Length; i++) {
                for (int j = 0; j < e.Band.SortedColumns.Count; j++) {
                    Infragistics.Win.UltraWinGrid.UltraGridColumn column = e.Band.SortedColumns[j];
                    if (column.Key == oldSort[i].Key) {
                        if (column.SortIndicator == Infragistics.Win.UltraWinGrid.SortIndicator.Ascending) {
                            //column.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.None;
                            e.Band.SortedColumns.Remove(column.Key);
                            j--;
                            break;
                        }
                    }
                }
            }
        }
