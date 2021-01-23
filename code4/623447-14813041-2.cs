    public object[] MultiplyNTimesObj(double number1, double number2, double timesToMultiply)
    {
         object[] result = new object[] { "MultiplyNTimesObj=", number1 };
         for (double i = 0; i < timesToMultiply; i++)
         {
             result[1] = (double)result[1] * number2;
         }
    
         return result;
    }
