    int num1;
    public void Num1Method()
    {
       string tempVal;  
       do
       {
          Console.Write("Enter Num1: ");
          tempVal = Console.ReadLine();          
       }
       while(class2Object.IntErrorCheckMethod(tempVal, out num1));
    }
