    class Program
    {
        static void Main(string[] args)
        {
            int max=0;
            int smax=0;
            int i;
            int[] a = new int[20];
            Console.WriteLine("enter the size of the array");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("elements");
            for (i = 0; i < n; i++)
            {
                a[i] = int.Parse(Console.ReadLine());
            }
            for (i = 0; i < n; i++)
            {
                if ( a[i]>max)
                {
                    smax = max;
                    max= a[i];
                }
                else if(a[i]>smax)
                {
                    smax=a[i];
                }
            }
            Console.WriteLine("max:" + max);
           
            Console.WriteLine("second max:"+smax);
                Console.ReadLine();
        }
    }
}
