    public static void Shuffle<T>(IList<T> list)
    {
        var random = new Random();
        for (int index = list.Count - 1; index >= 1; index--)
        {
            int other = random.Next(0, index + 1);
            T temp = list[index];
            list[index] = list[other];
            list[other] = temp;
        }
    }
