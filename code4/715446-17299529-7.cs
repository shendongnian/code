    public class Expression
    {
      public virtual int Evaluate()
      {
      }
    }
    public class Add : Expression
    {
      Expression _left;
      Expression _right;
      
      public Add(Expression left, Expression right)
      {
        _left = left;
        _right = right;
      }
      override int Evalute()
      {
        return _left.Evalute() + _right.Evalute();
      }
    }
    public class Parameter : Expression
    {
      public int Value{get;set;}
      
      public Parameter(string name)
      {
        // Use the name however you need.
      }
      
      override int Evalute()
      {
        return Value;
      }
    }
