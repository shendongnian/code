    public static void PopulateScoreArray(string[] array)
    {
        // Prompt user for names and assign values to the elements of the array
        for (int intCounter = 0; intCounter < array.Length; intCounter++)
        {
            Console.Write("Enter score for {0}: ", array[intCounter]);
            arrayScore[intCounter] = Convert.ToInt32(Console.ReadLine());
        }
    }
