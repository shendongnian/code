		public void OnConnection(object application, Extensibility.ext_ConnectMode connectMode, object addInInst, ref System.Array custom)
		{
			applicationObject = (Outlook.Application)application;
            this.applicationObject.ActiveExplorer().SelectionChange += new Microsoft.Office.Interop.Outlook.ExplorerEvents_10_SelectionChangeEventHandler(Explorer_SelectionChange);
		}
        void Explorer_SelectionChange()
        {
            if (applicationObject.ActiveExplorer().Selection.Count == 1)
            {
                Outlook.MailItem item = applicationObject.ActiveExplorer().Selection[1] as Outlook.MailItem;
     
                if (item != null)
                {
                   string address = item.SenderEmailAddress;
                   //do something
                }
            }
        }
