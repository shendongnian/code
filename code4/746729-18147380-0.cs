    private static void Main(string[] args)
        {
            int num = 10;
            Console.Write("Given the number " + num + " : multiples of 3 = {");
            
            for (int i = 3; i < num; i+=3)
                Console.Write((i!=3) ? ";"+i : i.ToString());
            Console.Write("} + remainder = " + num%3);
            
        }
