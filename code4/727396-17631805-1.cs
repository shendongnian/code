    public class Node1 : NodeState
    {
        private readonly Object ctx;
        public Node1(Object ctx)
        {
            this.ctx = ctx;
        }
        public void Handle()
        {
            if (ctx.Color.Equals("Red"))
                ctx.State = new Node2(ctx);
            else
                ctx.State = new Node3(ctx);
        }
    }
