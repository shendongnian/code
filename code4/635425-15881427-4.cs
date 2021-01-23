    Microsoft.Office.Tools.CustomTaskPane ctp;
    private HistoryPane ctrl;
    string title = "Task History";
    ctrl = new HistoryPane(mailItem);
    ctp = Globals.ThisAddIn.CustomTaskPanes.Add(ctrl, title);
    ctp.Visible = true;
    ctp.Width = 460;
    ctp.DockPosition = Microsoft.Office.Core.MsoCTPDockPosition.msoCTPDockPositionRight;
    ctrl.SetControl(ref ctp);
