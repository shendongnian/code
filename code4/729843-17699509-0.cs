    using (var enumerator = dummyklasse.Enumerator)
    {
        while (enumerator.MoveNext())
        {
            Console.WriteLine(enumerator.Current);
        }
    }
