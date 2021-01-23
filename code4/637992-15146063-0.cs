    double sum = 0.0;
    int count = 100000;
    for (int i = 0; i < count; ++i) {
        sum += 200000.0;
    }
    double average = sum / (double)count;
    Console.WriteLine(average); // prints out exactly 200000
