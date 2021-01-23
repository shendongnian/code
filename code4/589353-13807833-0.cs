        static void Main(string[] args)
    {
        int num1, i, j, x, y;
        Console.WriteLine("enter number");
        num1=int.Parse(Console.ReadLine());
        for (i=1; i<num1; i++){
            for (j=1; j<i+1; j++) {
            Console.Write(i);
    
            }Console.Write("\n"); 
        }
         for (x=num1; x>=0; x--){
            for (y=0; y<x; y++) {
            Console.Write(x);
    
            }Console.Write("\n"); 
        }
        Console.ReadLine();
    }
