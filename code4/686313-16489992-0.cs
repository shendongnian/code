    [Theory]
    void GivenAnEvenIntegerAndAnOddInteger_ProductIsAnEvenInteger(int a, int b)
    {
        Assume.That(a.IsEven());
        Assume.That(b.IsOdd());
        // note: the type system already ensures that `a` and `b` are integers.
        int product = a * b;
        Assert.That(product.IsEven());
        // note: the theory doesn't require `product` to be an integer, so even
        // if the type system didn't already assert this, we would not test for it.
    }
    [Datapoints]
    int[] integers = { 1, 2, 3, 4, 5, 6, 7 };
    static bool IsEven(this int integer) { … }
    static bool IsOdd(this int integer) { … }
