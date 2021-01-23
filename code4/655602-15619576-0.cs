    static void BubbleSort(int[] score, string[] names)
    {
        for (int j = 0; j < score.Length -1; j++)
        {
            for (int i = 0; i < score.Length - 1; i++)
            {
                if (score[i] > score[i + 1])
                {
                    Swap(ref score[i], ref score[i + 1]);
                    Swap(ref names[i], ref names[i + 1]);
                }
            }
        }
        foreach (int a in score)
            Console.WriteLine("{0}", a);
        Console.ReadLine();
    }
