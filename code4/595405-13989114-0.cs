    // Holds function scope etc.
    class Context { … }
    
    abstract class Node {
        public abstract object Execute(Context ctx);
    }
    
    class Number {
        private readonly int x;
    
        public Number(int x) { this.x = x; }
    
        public object Execute(Context ctx) { return x; }
    }
    
    class Addition {
        private readonly Node left, right;
    
        public Addition(Node left, Node right) {
            this.left = left;
            this.right = right;
        }
    
        public object Execute(Context ctx) {
            // Verification omitted: do the nested expressions evaluate to a number?
            return ((int) (left.Execute(ctx)) + ((int) (right.Execute(ctx))
        }
    }
