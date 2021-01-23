        static void Main(string[] args)
        {
            // this code needs a reference to UIAutomationClient and UIAutomationTypes
            Process process = Process.Start("devmgmt.msc");
            do
            {
                process.Refresh();
                Thread.Sleep(100);
            }
            while (process.MainWindowHandle == IntPtr.Zero);
            // get root element that corresponds to the process main window
            AutomationElement mainWindow = AutomationElement.FromHandle(process.MainWindowHandle);
            // get the first tree view control by its class name
            AutomationElement treeView = mainWindow.FindFirst(TreeScope.Subtree, new PropertyCondition(AutomationElement.ClassNameProperty, "SysTreeView32"));
            // get the "Keyboards" node by its name
            AutomationElement keyBoards = treeView.FindFirst(TreeScope.Subtree, new PropertyCondition(AutomationElement.NameProperty, "Keyboards"));
            
            // expand item
            ((ExpandCollapsePattern)keyBoards.GetCurrentPattern(ExpandCollapsePattern.Pattern)).Expand();
            // get first keyboard
            AutomationElement firstKeyboard = keyBoards.FindFirst(TreeScope.Children, PropertyCondition.TrueCondition);
            // open the first keyboard properties (focus + press ENTER)
            firstKeyboard.SetFocus();
            SendKeys.SendWait("{ENTER}");
        }
