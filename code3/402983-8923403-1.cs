    protected void RadGrid1_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
    {
        if (e.CommandName == Telerik.Web.UI.RadGrid.ExportToExcelCommandName ||
                e.CommandName == Telerik.Web.UI.RadGrid.ExportToWordCommandName ||
                e.CommandName == Telerik.Web.UI.RadGrid.ExportToPdfCommandName ||
                e.CommandName == Telerik.Web.UI.RadGrid.ExportToCsvCommandName)
        {
            gridResult.ExportSettings.IgnorePaging = true;
            gridResult.ExportSettings.OpenInNewWindow = true;
            if (e.CommandName == Telerik.Web.UI.RadGrid.ExportToExcelCommandName)
                gridResult.MasterTableView.ExportToExcel();
            else if (e.CommandName == Telerik.Web.UI.RadGrid.ExportToWordCommandName)
                gridResult.MasterTableView.ExportToWord();
            else if (e.CommandName == Telerik.Web.UI.RadGrid.ExportToCsvCommandName)
                gridResult.MasterTableView.ExportToCSV();
            else if (e.CommandName == Telerik.Web.UI.RadGrid.ExportToPdfCommandName)
                gridResult.MasterTableView.ExportToPdf();
        }
    }
