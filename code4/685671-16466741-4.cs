    using System;
    using System.Linq;
    public static T[][][] NewJagged<T>(
            int h,
            int w,
            ing d,
            Func<int, int, int, T> initializer = null,
            bool parallelize = true)
    {
        if (h < 1)
        {
            throw new ArgumentOutOfRangeException("h", h, "Dimension less than 1.")
        }
        if (w < 1)
        {
            throw new ArgumentOutOfRangeException("w", w, "Dimension less than 1.")
        }
        if (d < 1)
        {
            throw new ArgumentOutOfRangeException("d", d, "Dimension less than 1.")
        }
        if (initializer == null)
        {
            initializer = (i, j, k) => default(T);
        }
        if (parallelize)
        {
            return NewJaggedParalellImpl(h, w, d, initializer);
        } 
        return NewJaggedImpl(h, w, d, initializer);
    }
    private static T[][][] NewJaggedImpl<T>(
            int h,
            int w,
            int d,
            Func<int, int, int, T> initializer)
    {
        var result = new T[h][][];
        for (var i = 0; i < h; i++)
        {
            result[i] = new T[w][];
            for (var j = 0; j < w; j++)
            {
                result[i][j] = new T[d];
                for (var k = 0; k < d; k++)
                {
                    result[i][j][k] = initializer(i, j, k);
                }
            }
        }
        return result;
    }
    private static T[][][] NewJaggedParalellImpl<T>(
            int h,
            int w,
            int d,
            Func<int, int, int, T> initializer)
    {
        var result = new T[h][][];
        ParallelEnumerable.Range(0, h).ForAll(i =>
        {
            result[i] = new T[w][];
            ParallelEnumerable.Range(0, w).ForAll(j =>
            {
                result[i][j] = new T[d];
                ParallelEnumerable.Range(0, d).ForAll(k =>
                {
                    result[i][j][k] = initializer(i, j, k);
                });
            });
        });
        return result;
    }            
