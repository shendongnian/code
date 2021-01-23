    public void printReport(string header, params int[] list) 
    {
        Console.WriteLine(header);
        
        for (int i = 0 ; i < list.Length; i++)
        {
            Console.WriteLine(list[i]);
        }
        Console.WriteLine();
    }
