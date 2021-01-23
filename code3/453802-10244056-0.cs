    Double[] inputxx = new Double[inputx.Length / 5];
    int x = 0;
    for (int i = 0; i < inputx.Length; i += 5)
    {
         inputxx[x] = inputx[i];
         x++;
    }
