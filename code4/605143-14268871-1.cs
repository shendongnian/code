    public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> enumerable, Random random)
    {
        List<T> itemList = new List<T>(enumerable);
        for (int i = 0; i < itemList.Count; ++i)
        {
            int randomIndex = random.Next(itemList.Count);
            if (randomIndex != i)
            {
                T temp = itemList[i];
                itemList[i] = itemList[randomIndex];
                itemList[randomIndex] = temp;
            }
        }
        foreach (T item in itemList)
            yield return item;
    }
