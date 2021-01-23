    [Test]
    public void KendallTest()
    {
        float[] input = { 0.5f, 2f, 5f, 0.1f, 4f, 0.4f };
        FloatParallelArray fpa = new FloatParallelArray(input);
        CUDATarget target = new CUDATarget();
        float[] output = target.ToArray1D(fpa);
        Assert.IsTrue(input.SequenceEqual(output));
    }
