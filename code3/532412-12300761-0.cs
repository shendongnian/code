    public class NodeRepository{
        public Node EditNode(Node toEdit, int userId){
            using(new TransactionScope())
            {            
                //Edit Node in NodeContext like you would anyway without repository
                NodeContext.NodeHistories.Add(new NodeHistory(){//initialise NodeHistory stuff here)
                NodeContext.SaveChagnes();
            }
        }
    }
    public class NodeContext:DbContext{
        public DbSet<Node> Nodes{get;set;}
        public DbSet<NodeHistory> NodeHistories{get;set;}
    }
