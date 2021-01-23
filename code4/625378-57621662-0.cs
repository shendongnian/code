     static void Main(string[] args)
            {
                int[] arr = new int[5];
                int i, j,k;
                Console.WriteLine("Enter Array");
                for (i = 0; i < 5; i++)
                {
                    Console.Write("element - {0} : ", i);
                    arr[i] = Convert.ToInt32(Console.ReadLine());
                }
                Console.Write("\nElements in array are: ");
                j=arr[0];
                k=j;
                for (i = 1; i < 5; i++)
                {
                        if (j < arr[i])
                        {
                            if(j>k)
                            {
                                k=j;
                            }
                            j=arr[i];
                        }  
                }
                Console.WriteLine("First Greatest element: "+ j);
                Console.WriteLine("Second Greatest element: "+ k);
                Console.Write("\n");
            }
