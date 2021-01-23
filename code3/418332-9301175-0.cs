    for (int i = 0; i < arrayOfMessages.GetLength(0); i++)
    {
        for (int j = 0; j < arrayOfMessages.GetLength(1); j++)
        {
            string s = arrayOfMessages[i, j];
            Console.WriteLine(s);
        }
    }
