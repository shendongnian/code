    private void ThisAddIn_Startup(object sender, System.EventArgs e) {
        this.Application.ItemSend += new Outlook.ApplicationEvents_11_ItemSendEventHandler(Application_ItemSend);
    }
    void Application_ItemSend(object Item, ref bool Cancel) {
        ThisRibbonCollection ribbonCollection = Globals.Ribbons[Globals.ThisAddIn.Application.ActiveInspector()];
        if (ribbonCollection.MyRibbon.MyCheckbox1.Checked) {
        } else { 
        }
    }
