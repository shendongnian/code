    private static unsafe double SumProductPointer(double[] X, double[] Y)
    {
        double sum = 0;
        int length = X.Length;
        if (length != Y.Length)
            throw new ArgumentException("X and Y must be same size");
        fixed (double* xp = X, yp = Y)
        {
            for (int i = 0; i < length; i++)
                sum += xp[i] * yp[i];
        }
        return sum;
    }
