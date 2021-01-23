    public class TreeNode : PropertyChangedNotifier
    {
      private Label text;
      private System.Drawing.Image icon;
      private ObservableCollection<TreeNode> children;
    }
            <ig:XamDataTree.GlobalNodeLayouts>
                <ig:NodeLayout
                    Key="Children"
                    DisplayMemberPath="Text"
                    TargetTypeName="Model.TreeNode" 
                    >
                </ig:NodeLayout>
            </ig:XamDataTree.GlobalNodeLayouts>
