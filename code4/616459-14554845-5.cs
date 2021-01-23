    [Fact]
    public void ConsumerShouldConsume() {
        var produced = 0;
        var consumed = 0;
        Func<int> produce = () => {
            Thread.Sleep(TimeSpan.FromMilliseconds(100));
            produced++;
            return new Random(2).Next(1000);
        };
        Action<int> consume = c => { consumed++; };
        var t = new ProducerConsumer<int>(produce, consume);
        t.Start();
        Thread.Sleep(TimeSpan.FromSeconds(5));
        t.Stop();
        Assert.InRange(produced,40,60);
        Assert.InRange(consumed, 40, 60);
    }
