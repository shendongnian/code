    static void Run() {
        int n = 10;
        double[] myArr = new double[n];
        for (int i = n - 1; i >= 0; i--) { myArr[i] = (double)i*i; }
        // sqrt_min contains minimal sqrt-value
        double sqrt_min = double.MaxValue;
        Parallel.ForEach(myArr, num => {
            double sqrt = Math.Sqrt(num); // some time consuming calculation that should be parallized
            if (sqrt < sqrt_min) { sqrt_min = sqrt; }
        });
        if (sqrt_min > 0) {
            Console.WriteLine("minimum: " + sqrt_min);
        }
    }
    static void Main() {
        for (int i = 0; i != 100000; i++ ) {
            Run();
        }
    }
