    public static IEnumerable<uint> Foo(uint startValue =0, uint maxValue = uint.MaxValue)
    {
        uint index = startValue;
        while(index < maxValue) {
            yield return index++;
        }
    }
    public static void Main()
    {
        var myUints = Foo().Take(100);
        var myUints2 = Foo(startValue:0, maxValue:1000);
        foreach(uint x in myUints) {
            Console.WriteLine(x);
        }
    }
