    private bool CheckInputisinExcelCell()
    {
        Microsoft.Office.Core.CommandBarControl cmdEdited;
        cmdEdited=YourExcelApplicationobject.CommandBars.FindControl(Microsoft.Office.Core.MsoControlType.msoControlButton, 23, System.Reflection.Missing.Value, System.Reflection.Missing.Value);
        return cmdEdited.Enabled;
    }
