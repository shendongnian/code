    public abstract class ExpressionBase {
     public float value {get;set;}
    }
    
    public class GreaterThanExpression : ExpressionBase {}
    public class LessThanExpression : ExpressionBase {}
