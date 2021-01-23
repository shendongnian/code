     if ((xamGridtemplateDet.ItemsSource).Count > 0)
            {
                Workbook wrkbook = new Workbook();
                Worksheet wrkSHT = wrkbook.Worksheets.Add("Sheet 1");
                wrkSHT.DisplayOptions.PanesAreFrozen = true;
                wrkSHT.DisplayOptions.FrozenPaneSettings.FrozenRows = 1;
                wrkSHT.DefaultColumnWidth = 5000;
                int currentcolumn = 0;
                foreach (TemplateDetailUI column in xamGridtemplateDet.ItemsSource)
                {
                    if (column != null)
                    {
                        SetCellValue(wrkSHT.Rows[0].Cells[currentcolumn], column.ColumnName);
                        currentcolumn++;
                    }
                }
          
                SaveExport(wrkbook);
}
         public void SaveExport(Workbook dataworkbook)
        {
            try
            {
                bool? showDialog = this.dialog.ShowDialog();
                if (showDialog == true)
                {
                    using (System.IO.Stream exportstream = dialog.OpenFile())
                    {
                        dataworkbook.Save(exportstream);
                        exportstream.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                
               throw ex;
            }
            
        }
