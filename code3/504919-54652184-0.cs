    TreeView.FullRowSelect Property 
    
    Gets or sets a value indicating whether the selection highlight spans the width of the tree view control.
    
    public class CustomizedTreeView : TreeView
        {
            public CustomizedTreeView()
            {`enter code here`
                // Customize the TreeView control by setting various properties.
                BackColor = System.Drawing.Color.CadetBlue;
                FullRowSelect = true;
                HotTracking = true;
                Indent = 34;
                ShowPlusMinus = false;
        
                // The ShowLines property must be false for the FullRowSelect 
                // property to work.
                ShowLines = false;
            }
        
            protected override void OnAfterSelect(TreeViewEventArgs e)
            {
                // Confirm that the user initiated the selection.
                // This prevents the first node from expanding when it is
                // automatically selected during the initialization of 
                // the TreeView control.
                if (e.Action != TreeViewAction.Unknown)
                {
                    if (e.Node.IsExpanded) 
                    {
                        e.Node.Collapse();
                    }
                    else 
                    {
                        e.Node.Expand();
                    }
                }
        
                // Remove the selection. This allows the same node to be
                // clicked twice in succession to toggle the expansion state.
                SelectedNode = null;
            }
        
        }
    
    
    follow this link
    
    https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.treeview.padding?view=netframework-4.7.2
