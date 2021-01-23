    //Create SwapVisitor to merge the parameters from each property expression into one  
    public class SwapVisitor : ExpressionVisitor  
    {  
        private readonly Expression from, to;  
        public SwapVisitor(Expression from, Expression to)  
        {  
            this.from = from;  
            this.to = to;  
        }  
        public override Expression Visit(Expression node)  
        {  
            return node == from ? to : base.Visit(node);  
        }  
        public static Expression Swap(Expression body, Expression from, Expression to)  
        {  
            return new SwapVisitor(from, to).Visit(body);  
        }  
    }  
