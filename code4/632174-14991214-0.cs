     int size = 0, k = 0;
     Console.WriteLine("Enter size of array: ");
     size = Convert.ToInt32(Console.ReadLine());
     string[] array = new string[size];
     for (int i = 0; i < size; i++)
     {
         Console.WriteLine("Enter at index: {0}", i);
         array[i] = Console.ReadLine();
     }
     foreach (string s in array)
     {
         Console.WriteLine("Value at index: {0}", k + " = " + s);
         k++;
     }
     Console.ReadLine();
