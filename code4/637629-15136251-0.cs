     public enum Operator
        {
            PLUS, MINUS, MULTIPLY, DIVIDE
        }
    
        public class Calc
        {
            public void Calculate(int left, int right, Operator op)
            {
    
                switch (op)
                {
                    case Operator.DIVIDE:
                        //Divide
                        break;
                    case Operator.MINUS:
                        //Minus
                        break;
                    case Operator.MULTIPLY:
                        //...
                        break;
                    case Operator.PLUS:
                        //;;
                        break;
                    default:
                        throw new InvalidOperationException("Couldn't process operation: " + op);
                }
            }
        }
