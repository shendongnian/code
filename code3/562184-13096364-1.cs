    int Counter285= 0, Counter134 = 0, Counter085 = 0;
    int Price285= 0, Price134 = 0, Price085 = 0;
    double[] arr = new double[] { Counter285, Counter134, Counter085 };
    foreach (double i in arr)
    {
        if (i == Counter285)
        {
            Price285 += Counter285;
        }
        else if (i == Counter134)
        {
            Price134 += Counter134;
        }
        else
        {
            Price085 += Counter085;
        }
    }
