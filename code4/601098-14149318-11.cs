    public class Math : IMath, IMathRest
    {
         public int Add(int Number1, int Number2)
         {
             return Number1 + Number2;
         }
    
         public int AddRest(string Number1, string Number2)
         {
             int num1 = Convert.ToInt32(Number1);
             int num2 = Convert.ToInt32(Number2);
             return num1 + num2;
         }
    }
