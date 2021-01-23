    double[, ,] numbers = new double[2, 2, 2];
    numbers[0, 0, 0] = 0;
    numbers[0, 0, 1] = 1;
    numbers[0, 1, 0] = 2;
    numbers[0, 1, 1] = 3;
    numbers[1, 0, 0] = 4;
    numbers[1, 0, 1] = 5;
    numbers[1, 1, 0] = 6;
    numbers[1, 1, 1] = 7;
    double[] xmax = new double[numbers.GetLength(0)];
    double[] ymax = new double[numbers.GetLength(1)];
    double[] zmax = new double[numbers.GetLength(2)];
    for (int x = 0; x < xmax.Length; x++) xmax[x] = int.MinValue;
    for (int y = 0; y < ymax.Length; y++) ymax[y] = int.MinValue;
    for (int z = 0; z < zmax.Length; z++) zmax[z] = int.MinValue;
    for (int x = 0; x < xmax.Length; x++)
        for (int y = 0; y < ymax.Length; y++)
            for (int z = 0; z < zmax.Length; z++)
            {
                xmax[x] = Math.Max(xmax[x], numbers[x, y, z]);
                ymax[y] = Math.Max(ymax[y], numbers[x, y, z]);
                zmax[z] = Math.Max(zmax[z], numbers[x, y, z]);
            }
    // xmax == { 3, 7 }
    // ymax == { 5, 7 }
    // zmax == { 6, 7 }
