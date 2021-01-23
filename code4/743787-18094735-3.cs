    public class TransTree
    {
        //public string itemName;
        //public List <TransNode> nodes;
        public List <TransLevel> levels = new List<TransLevel>();
        public TransNode root { private set; get; }
        public TransTree(string itemName)
        {
        //	this.itemName = itemName;
        	root = new TransNode(itemName, null);
        }
    }
