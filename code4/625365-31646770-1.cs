    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                int size;
                Console.WriteLine("Enter the size of array");
                size = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter the element of array");
                int[] arr = new int[size];
                for (int i = 0; i < size; i++)
                {
                    arr[i] = Convert.ToInt32(Console.ReadLine());
                }
                int length = arr.Length;
                Program program = new Program();
                program.SeconadLargestValue(arr, length);
            }
    
            private void SeconadLargestValue(int[] arr, int length)
            {
                int maxValue = 0;
                int secondMaxValue = 0;
                for (int i = 0; i < length; i++)
                {
                    if (arr[i] > maxValue)
                    {
                        secondMaxValue = maxValue;
                        maxValue = arr[i];
                    }
                    else if(arr[i] > secondMaxValue)
                    {
                        secondMaxValue = arr[i];
                    }
                }
                Console.WriteLine("First Largest number :"+maxValue);
                Console.WriteLine("Second Largest number :"+secondMaxValue);
                Console.ReadLine();
            }   
        }
    }
