    private void btnExportToExcel_Click(object sender, EventArgs e)
    {
        var dia = new System.Windows.Forms.SaveFileDialog();
        dia.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        dia.Filter = "Excel Worksheets (*.xlsx)|*.xlsx|xls file (*.xls)|*.xls|All files (*.*)|*.*";
        if(dia.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
        {
            DataTable data = null;// use the DataSource of the DataGridView here
            var excel = new OfficeOpenXml.ExcelPackage();
            var ws = excel.Workbook.Worksheets.Add("worksheet-name");
            // you can also use LoadFromCollection with an `IEnumerable<SomeType>`
            ws.Cells["A1"].LoadFromDataTable(data, true, OfficeOpenXml.Table.TableStyles.Light1);
            ws.Cells[ws.Dimension.Address.ToString()].AutoFitColumns();
            using(var file = File.Create(dia.FileName))
                excel.SaveAs(file);
        }
    }
