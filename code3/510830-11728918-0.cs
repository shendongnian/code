    using System;  
    class AscendingBubbleSort 
    {     
        public static void Main()
        {
            int i = 0,j = 0,t = 0;
            int []c=new int[20];
            for(i=0;i<20;i++)
            {
                Console.WriteLine("Enter Value p[{0}]:", i);
                c[i]=int.Parse(Console.ReadLine());
            }
            // Sorting: Bubble Sort
            for(i=0;i<20;i++)
            {
                for(j=i+1;j<20;j++)
                {
                    if(c[i]>c[j])
                    {
                        Console.WriteLine("c[{0}]={1}, c[{2}]={3}", i, c[i], j, c[j]);
                        t=c[i];
                        c[i]=c[j];
                        c[j]=t;
                    }
                }
            }
            Console.WriteLine("Here comes the sorted array:");
            // Print the contents of the sorted array
            for(i=0;i<20;i++)
            {
                Console.WriteLine ("c[{0}]={1}", i, c[i]);
            }
        }
    }
