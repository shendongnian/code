        private void grd_InitializeRow(object sender, InitializeRowEventArgs e)
        {
            if (e.ReInitialize == false)
            {
                UltraGridColumn c = e.Row.Band.Columns["Value"];
                string link = e.Row.GetCellValue(c).ToString();
                if(Uri.IsWellFormedUriString(link, UriKind.Absolute))
                    e.Row.Cells["Value"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.URL;
            }
        }
