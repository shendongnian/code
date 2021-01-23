    int[] randomNumbers = Shuffle(Enumerable.Range(0, 11)).ToArray(); 
        
    public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source)
    {
        Random random = new Random((int)(DateTime.Now.ToBinary() % Int32.MaxValue));
        List<T> list = source.ToList();
        // save count so we don't have to calculate it with each iteration of loop
        int count = list.Count;
    
        while (count > 0)
        {
            int index = random.Next(count--);
            yield return list[index];
            list.RemoveAt(index);
        }
    }
