    public partial class ContextMenuLookupAddin
    {
        Outlook.Explorer currentExplorer = null;
        CommandBarButton contextButton = null;
        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            currentExplorer = Application.ActiveExplorer();
            Application.ItemContextMenuDisplay += Application_ItemContextMenuDisplay;
            Application.ContextMenuClose +=Application_ContextMenuClose;
        }
        private void Application_ItemContextMenuDisplay(Microsoft.Office.Core.CommandBar CommandBar, 
                                                        Selection Selection)
        {
            if (contextButton == null)
            {
                contextButton = (Office.CommandBarButton)CommandBar.Controls.
                                    Add(Office.MsoControlType.msoControlButton, missing,
                                        missing, missing, missing);
                contextButton.accName = "SowSelectedItem";
            }
            
            contextButton.DescriptionText = "Show Selected item";
            contextButton.Caption = contextButton.DescriptionText;
            contextButton.Tag = "ShowSelectedItem";
            contextButton.FaceId = 4000;
            contextButton.OnAction = "OutlookIntegration.ThisAddIn.ContextMenuItemClicked";
            contextButton.Click += ContextMenuItemClicked;
        }
        private void Application_ContextMenuClose(OlContextMenu ContextMenu)
        {
            contextButton.Click -= ContextMenuItemClicked;
            contextButton.Delete(missing);
            contextButton = null;
        }
        private void ContextMenuItemClicked(CommandBarButton Ctrl, ref bool CancelDefault)
        {
            if (currentExplorer.Selection.Count > 0)
            {
                object selObject = currentExplorer.Selection[1];
                if (selObject is MailItem)
                {
                    // do your stuff with the selected message here
                    MailItem mail = selObject as MailItem;
                    MessageBox.Show("Message Subject: " + mail.Subject);
                }
            } 
        }
     }
