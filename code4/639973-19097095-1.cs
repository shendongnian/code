    static void Main(string[] args)               
    {
         //Factorial six
         int ans = 1;
         int num = 7; 
         for (int i = 1; i < num; i++)
         {
              ans = ans * i;
         }
         Console.WriteLine(ans.ToString());
         Console.ReadLine();       
    }
