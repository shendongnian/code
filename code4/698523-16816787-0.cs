    public static Vector<T> ApplyExtension<T>(this Matrix<T> x, Func<Vector<T>, T> myOperation)
    {
       var res = new DenseVector<T>(x.ColumnCount, 0);
       for (int i = 0; i < x.ColumnCount; i++)
       {
           res[i] = myOperation(x.Row(i));
       }
       return res;
    }
