    using Office = Microsoft.Office.Core;
    using Outlook = Microsoft.Office.Interop.Outlook;
    
    private void MyAddIn_Startup(object sender, System.EventArgs e)
    {
    	Office.CommandBarButton bts = (Office.CommandBarButton)CommandBar.Controls.Add();
    	bts.Visible = true;
    	bts.Caption = "Save selected messages to disk";
    	bts.Click += new Office._CommandBarButtonEvents_ClickEventHandler(bts_Click);
    }
    
    private void bts_Click(Office.CommandBarButton Ctrl, ref bool CancelDefault)
    {
    	Outlook.Selection list = this.Application.ActiveExplorer().Selection;
    
    	string fileName = "";
    
    	Object selObject;
    	Outlook.MailItem mailItem;
    
    	for (int i = 1; i < list.Count + 1; i++)
    	{
    		selObject = this.Application.ActiveExplorer().Selection[i];
    
    		if (selObject is Outlook.MailItem)
    		{
    			mailItem = (selObject as Outlook.MailItem);
    
    			if (mailItem != null)
    			{
    				fileName = Path.GetTempFileName();
    				mailItem.SaveAs(fileName, Outlook.OlSaveAsType.olMSG);
    			}
    		}
    	}
    }
