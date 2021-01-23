    private void grdItemlogs_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            if (e.Row != null)
            {
                string toolTipText = "Your Tooltip string content"
                e.Row.ToolTip = toolTipText;
            }
        }
