    int[] randomNumbers = Shuffle(Enumerable.Range(0, 11)).ToArray(); 
    
    public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source)
    {
        Random random = new Random((int)(DateTime.Now.ToBinary() % Int32.MaxValue));
        List<T> list = source.ToList();
    
        while (list.Count > 0)
        {
            int index = random.Next(list.Count);
            yield return list[index];
            list.RemoveAt(index);
        }
    }
