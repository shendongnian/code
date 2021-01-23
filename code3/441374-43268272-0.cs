    const int arrayLength = 100000;
    const int numberCopies = 1000;
    var a = new int[arrayLength];
    var b = new int[arrayLength];
    var stopwatch = new Stopwatch();
    for (var i = 0; i < numberCopies; i++) {
        Array.Copy(a, b, arrayLength);
    }
    Console.WriteLine($"Copy: {stopwatch.ElapsedMilliseconds} ms");
    stopwatch.Restart();
    for (var i = 0; i < numberCopies; i++) {
        var c = new int[arrayLength];
        Array.Copy(a, c, arrayLength);
    }
    Console.WriteLine($"Copy (with allocation): {stopwatch.ElapsedMilliseconds} ms");
    stopwatch.Restart();
    for (var i = 0; i < numberCopies; i++) {
        b = (int[]) a.Clone();
    }
    Console.WriteLine($"Clone: {stopwatch.ElapsedMilliseconds} ms");
    stopwatch.Restart();
    for (var i = 0; i < numberCopies; i++) {
        b = a.ToArray();
    }
    Console.WriteLine($"ToArray: {stopwatch.ElapsedMilliseconds} ms");
