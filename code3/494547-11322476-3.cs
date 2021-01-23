        for (int i = 0; i <= arraySize - 1; i++)
        {
            Console.Write(string.Format("Value for Element {0}: ",i));
            value = int.Parse(Console.ReadLine());
            //arr[i] = int.Parse(Console.ReadLine()); // or you can do
            arr[i] = value;
        }
