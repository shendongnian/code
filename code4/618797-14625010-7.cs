    void f(double[] v, int startIndex, int count)
    {
        for (int i = 0 ; i < count ;  ++i, ++startIndex)
        {
              //access v[startIndex]
              //etc
        }
    }
    double[] v =new double[100];
    f(v, 10, 5); //note the difference here!
