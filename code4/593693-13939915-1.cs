    public class AnotherClass
    {
        public static void callSomeFunction(Func<double, double> y
            , Func<double, double> yDerivitive)
        {
            //store delegates for later use
        }
    }
    
    AnotherClass.callSomeFunction(TemplateFunction.y, TemplateFunction.yDerivative);
