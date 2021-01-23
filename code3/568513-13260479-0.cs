    <XamlDataGrid MouseEnter="XamlDataGridMouseEnter"/>
    private void XamlDataGridMouseEnter(object Sender, MouseEventArgs e)
    {
        ToolTipService.SetIsEnabled((XamlDataGrid)Sender, true);
    }
