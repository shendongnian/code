        static int num;
        static void Main(string[] args)
        {
            int[] array;
            Console.Write("enter the size of array : ");
            int input = int.Parse(Console.ReadLine());
            int[] temp;
            temp = new int[10];
            int a = 0;
            int count = 0;
            array = new int[input];
            for (int i = 0; i < input; i++)
            {
                Console.Write("enter value ( " + i + ", " + input+") :");
                array[i] = int.Parse(Console.ReadLine());
            }
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < array.Length; j++)
                {
                    if (i == array[j])//compare i with array
                    {
                        count++;
                        if (a < count)//if greator found
                        {
                            
                            a = count;
                            num = i;
                        }
                    }
                    else
                    {
                        count = 0;
                    }
                }   
            }
            Console.WriteLine(num +" repeated " + a +" times");
            Console.ReadKey();
        }
