    static void Main(string[] args) {
        Console.WriteLine("{0}", SumRecursive(1,10));
    }
    static int SumRecursive(int min, int max) {
        return _SumRecursive(min, max);
    }
    static int _SumRecursive(int min, int val) {
        if (val == min)
            return val;
        return val + _SumRecursive(min, val - 1);
    }
