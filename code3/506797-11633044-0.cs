    public class BTNode
    {
        public BTNode() { }
        public BTNode(int value) { Value = value; }
        public int Value { get; set; }
        public BTNode Left { get; set; }
        public BTNode Right { get; set; }
        public BTNode Parent { get; set; }
    }
    public class BinaryTree
    {
        public BinaryTree() { }
        public BTNode Root { get; private set; }
        public int Size { get; private set; }
        public void AddNode(int value)
        {
            BTNode insertNode = new BTNode(value);
            if (Root == null)
                Root = insertNode;
            else
                AddNodeToTree(Root, insertNode);
            Size++;
        }
        private void AddNodeToTree(BTNode parentNode, BTNode insertNode)
        {
            if (insertNode.Value >= parentNode.Value)
            {
                if (parentNode.Right != null)
                    AddNodeToTree(parentNode.Right, insertNode);
                else
                {
                    parentNode.Right = insertNode;
                    insertNode.Parent = parentNode;
                }
            }
            else
            {
                if (parentNode.Left != null)
                    AddNodeToTree(parentNode.Left, insertNode);
                else
                {
                    parentNode.Left = insertNode;
                    insertNode.Parent = parentNode;
                }
            }
        }
        public BTNode FindNode(int value)
        {
            return FindNode(Root, value);
        }
        public BTNode FindNode(BTNode parent, int value)
        {
            BTNode node = null;
            if (parent != null)
            {
                if (parent.Value == value)
                    node = parent;
                else
                {
                    if (parent.Value < value)
                        node = FindNode(parent.Right, value);
                    else
                        node = FindNode(parent.Left, value);
                }
            }
            return node;
        }
    }
