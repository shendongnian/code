    double *values = new double[10]; // the input
    double *averages = new double[10]; // the output
    values[0] = 55;
    values[1] = 113;
    values[2] = 92.6;
    ...
    values[9] = 23;
    moving_average(values, averages, 10, 5); // 5-day moving average
