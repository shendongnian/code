    Microsoft.Office.Tools.Excel.NamedRange setColumnRowRange;
        private void SetColumnAndRowSizes()
        {
            setColumnRowRange = this.Controls.AddNamedRange(
                this.Range["C3", "E6"], "setColumnRowRange");
            this.setColumnRowRange.ColumnWidth = 20;
            this.setColumnRowRange.RowHeight = 25;
            setColumnRowRange.Select();
        }
