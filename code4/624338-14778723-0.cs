    Reception.DropDown.Closing += new ToolStripDropDownClosingEventHandler(DropDown_Closing);
    private void DropDown_Closing(object sender, ToolStripDropDownClosingEventArgs e)
        {
            if (e.CloseReason == ToolStripDropDownCloseReason.ItemClicked )
               e.Cancel = true;
        }
