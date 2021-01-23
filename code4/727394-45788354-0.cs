    async void DoExport()
    {
        var rMsg = "";
        var t = await Task<bool>.Factory.StartNew(() => ExportAsMonthReport(LastMonth.Name, LastYear.Name, out rMsg));
        
        if (t)
        {
              BeginInvoke((Action)(() =>
              {
                   spinnerMain.Visible = false;
                   menuItemMonth.Enabled = true;
        
                   MetroMessageBox.Show(this, rMsg, "Export", MessageBoxButtons.OK, MessageBoxIcon.Information, 200);
              }));
       }
       else
       {
              BeginInvoke((Action)(() =>
              {
                   spinnerMain.Visible = false;
                   menuItemMonth.Enabled = true;
        
                   MetroMessageBox.Show(this, rMsg, "Export", MessageBoxButtons.OK, MessageBoxIcon.Error, 200);
              }));
        }
    }
