    public enum Operator
    {
        PLUS, MINUS, MULTIPLY, DIVIDE
    }
    public static double Calculate(int left, int right, Operator op)
    {
        switch (op)
        {
            default:
            case Operator.PLUS:
                return left + right;
            case Operator.MINUS:
                return left - right;
            case Operator.MULTIPLY:
                return left * right;
            case Operator.DIVIDE:
                return left / right;
        }
    }
