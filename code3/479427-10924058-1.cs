     [ClassInterface(ClassInterfaceType.None)]
     [ComSourceInterfaces(typeof(ICalculatorEvents))]
     [Guid("87457845-945u48-4954")]
     public class Calculator : ICalculator
     {
         public ICalculatorEvents callbackObject ;
         public Add(int Num1, int Num2)
         {
             int Result = Num1 + Num2;
             if(callbackObject != null)
                 callbackObject.Completed(Result);
         }
     }
