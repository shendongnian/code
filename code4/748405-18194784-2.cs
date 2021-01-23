    var start = Enumerable.Range(0, B.Length - A.Length + 1)
                          .Where(i => B.Skip(i).Take(A.Length).SequenceEqual(A))
                          .DefaultIfEmpty(-1)
                          .First();
    if (start != -1)
    {
        for (var i = 0; i < A.Length; ++i)
        {
            B[start + i] = " ";
        }
    }
