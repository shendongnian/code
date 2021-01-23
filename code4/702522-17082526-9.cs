     private void ThisWorkbook_Startup(object sender, System.EventArgs e)
            {
                ShowData._WORKBOOK = this;
            }
    private void ThisWorkbook_SheetFollowHyperlink(object Sh, Microsoft.Office.Interop.Excel.Hyperlink Target)
            {
                System.Data.DataTable dTable =  GenerateDatatable();
                showData sh = new showData(dTable);
                sh.Show(); // You can also use ShowDialog()
            }
