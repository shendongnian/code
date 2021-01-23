    public class MyTV : TreeView
    {
    protected bool TopOfCascade;
    TreeNode startNode;
    public Action FinishedCheckEventsDelegate;
    public Action InitiateCascadeCheckEventsDelegate;
    public MyTV()
      : base()
    {
      TopOfCascade = false;
      startNode = null;
    }
    protected override void OnBeforeCheck(TreeViewCancelEventArgs e)
    {
      base.OnBeforeCheck(e);
      if (!TopOfCascade && !e.Cancel)
      {
        TopOfCascade = true;
        startNode = e.Node;
        if (InitiateCascadeCheckEventsDelegate != null)
     InitiateCascadeCheckEventsDelegate();
      }
    }
    protected override void OnAfterCheck(TreeViewEventArgs e)
    {
      base.OnAfterCheck(e);
      if (startNode == e.Node && e.Action != TreeViewAction.Unknown)
      {
        if (FinishedCheckEventsDelegate != null) FinishedCheckEventsDelegate();
        TopOfCascade = false;
        startNode = null;
      }
    }
    `
