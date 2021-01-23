    private T SomeFunctionA<T>(T[][,] d, Func<T, T, T> aggregate, Func<T,T> postProcess)
    {
        T sum = default(T); 
        for (int k = 0; k < d.GetLength(0); k++)
            for (int j = 0; j < d[0].GetLength(1); j++)
                for (int i = 0; i < d[0].GetLength(0); i++)
                     sum = aggreagate(sum, d[k][i,j]);
        return postProcess(sum);
    }
