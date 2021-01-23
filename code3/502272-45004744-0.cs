      public static UITestControl GetTreeItem(UITestControl TreeControl, string ItemName, bool ContainsTrue = true)
        {
            AutomationElement tree = AutomationElement.FromHandle(TreeControl.WindowHandle);
            System.Windows.Automation.ControlType controlType = tree.Current.ControlType;
            //Get collection of tree nodes.
            AutomationElementCollection treeNodeCollection = null;
            treeNodeCollection = tree.FindAll(TreeScope.Descendants,
                    new System.Windows.Automation.PropertyCondition(AutomationElement.ControlTypeProperty,
                            System.Windows.Automation.ControlType.TreeItem));
            UITestControl ReqTreeItem = new UITestControl();
            foreach (AutomationElement item in treeNodeCollection)
            {
                if ((item.Current.Name == ItemName) && (!ContainsTrue))
                {
                    ReqTreeItem = UITestControlFactory.FromNativeElement(item, "UIA");
                    break;
                }
                if ((item.Current.Name.Contains(ItemName)) && (ContainsTrue))
                {
                    ReqTreeItem = UITestControlFactory.FromNativeElement(item, "UIA");
                    break;
                }
            }
            return ReqTreeItem;
        }
