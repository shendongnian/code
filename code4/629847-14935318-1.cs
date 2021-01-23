         public partial class Panel1
            {
                Panel2 pnl2;
                public Panel1()
                {
                   pnl2 = new Panel2();
                   pnl2.ShowExportClicked += new ShowExportReport(ShowExport);    
                }
        
                public void ShowExport(object sender, EventArgs e)
                {
                   .......
                }
            }
