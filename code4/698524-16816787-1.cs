    public static Vector<TResult> ApplyExtension<T, TResult>(this Matrix<T> x, Func<Vector<T>, TResult> myOperation)
    {
       var res = new DenseVector(x.ColumnCount, 0);
       for (int i = 0; i < x.ColumnCount; i++)
       {
           res[i] = myOperation(x.Row(i));
       }
       return res;
    }
