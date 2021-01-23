    public static IEnumerable<T> UseColumns<T>(List<T> list, int columns)
    {
        int columnHeight = list.Count / columns;
        for (int i = 0; i < columnHeight + 1; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                int index = i + columnHeight * j;
                if (index < list.Count)
                    yield return list[index];
            }
        }
    }
