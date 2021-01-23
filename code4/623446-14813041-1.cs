     public double[] MultiplyNTimesNextCell(double number1, double number2, double timesToMultiply)
    {
           // result[0] is the value returned on the first cell
           // result[1] is the value returned on the next cell
           double[] result = new double[] {0, number1};
           for (double i = 0; i < timesToMultiply; i++)
           {
                // hardcoded to result[1] where to return the result
                result[1] = result[1] * number2;
           }
    
            return result;
    }
