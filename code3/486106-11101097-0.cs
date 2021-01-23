    public abstract class TreeNodeBase
    {
        public long parentkey
        {
            get { return _parentkey; }
            set { _parentkey = value; this.OnChnaged(); }
        }
        protected long _parentkey;
    }
    public class MyEntityTreeNode : TreeNodeBase
    {
        public long coakey
        {
            get { return _coakey; }
            set { _coakey = value; this.OnChnaged(); }
        }
        protected long _coakey;
        // etc...
    }
    // Note the generic type constraint at the end of the next line
    public static List<T> BuildTree<T>(List<T> list, T selectNode, string keyPropName, string parentPropName, string levelPropName, int level) where T : TreeNodeBase
    {
        List<T> entity = new List<T>();
        foreach (TreeNodeBase node in list)
        {
            long parentKey = node.parentkey;
            // etc...
        }
        return entity;
    }
