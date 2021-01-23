    public enum Operator
    {
        PLUS, MINUS, MULTIPLY, DIVIDE
    }
    public double Calculate(int left, int right, Operator op)
    {
        double sum = 0.0;
        switch(op)
        {
           case Operator.PLUS:
           sum = left + right;
           return sum;
           case Operator.MINUS:
           sum = left - right;
           return sum;
           case Operator.MULTIPLY:
           sum = left * right;
           return sum;
           case Operator.DIVIDE:
           sum = (double)left / right;
           return sum;
           default:
           return sum;
       }
       return sum;
    }
