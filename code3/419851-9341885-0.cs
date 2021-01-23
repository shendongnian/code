    interface ISettingPanel
    {
    SettingContext Context{get;set;}
    }
    
    public BasicSettingPanel:Panel,ISettingPanel
    {
    ....
    }
    
    public void InitTreeView
    {
    var node=new TreeNode();
    node.Tage=new BasicSettingPanel();// or you can set the type to create the panel later
    treeView.Nodes.Add(node);
    }
    
    public void AfterNodeSelected()
    {
    _currentPanel=null;
    var selectedNode=treeView.SelectedNode;
    var panel=selectedNode.Tag as Panel;
    if(panel!=null)
    _currentPanel=panel;
    (_currentPanel as ISettingPanel).Context=this.Context;
    }
