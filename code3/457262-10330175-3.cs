    [DefaultProperty("Text")]
    [ToolboxData("<{0}:CustomTreeNode runat=server></{0}:CustomTreeNode>")]
    public class CustomTreeNode : TreeNode
    {
        public const int NODE_TYPE = 1;
        public const int NODE_ID = 2;
        public string NodeType { get; set; }
        public int NodeId { get; set; }
 
        protected override void LoadViewState(Object savedState)
        {
            if (savedState != null)
            {
                object[] myState = (object[])savedState;
                if (myState[0] != null)
                    base.LoadViewState(myState[0]);
                if (myState[NODE_TYPE] != null)
                    this.NodeType = (string)myState[NODE_TYPE];
                if (myState[NODE_ID] != null)
                    this.NodeId = (int)myState[NODE_ID];
            }
        }
        protected override Object SaveViewState()
        {
            object baseState = base.SaveViewState();
            object[] allStates = new object[3];
            allStates[0] = baseState;
            allStates[NODE_TYPE] = this.NodeType;
            allStates[NODE_ID] = this.NodeId;
            return allStates;
        }
    }
