    int k = 0;
    while (reader.Read())
    {
       A[k++] = reader.GetDouble(1);
    }
    int size = (int)(Math.Sqrt(2*k+0.25)-0.5);
