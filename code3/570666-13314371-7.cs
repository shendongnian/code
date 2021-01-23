    /**CODE**/
        class Program
        {
    
            public static void Main(string[] args)
            {
                C c = new C();
                Type myType = c.GetType();
                while(myType != null)
                {
                    Console.WriteLine(myType);
                    myType = myType.BaseType;
                }
                Console.ReadKey();
            }
        }
        
    /**OUTPUT**/
        StackOverflow.Demos.C
        StackOverflow.Demos.B
        StackOverflow.Demos.A
        System.Object
