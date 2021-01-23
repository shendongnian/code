    private Queue<SineWaveGenerator> generators;
    // constructor
    public Player()
    {
        for (int i = 0; i < 5; i++)
        {
            var generator = new SineWaveGenerator();
            generator.Amplitude = 0.25f;
            generators.Enqueue(generator);
        }
    }
    // just a helper method
    private SineWaveGenerator GetGenerator(int frequency)
    {
        return generators.FirstOrDefault(x => x.Frequency == frequency);
    }
    private void Play(int frequency)
    {
        var generator = GetGenerator(frequency);
        if (generator == null)
        {
            generator = generators.Dequeue(); // get generator from the top of the list
            generator.Frequency = GetFrequency(key); // modify the generator
            generators.Enqueue(generator); // and append it to the back
        }
        generator.Play();
    }
    private void Stop(int frequency)
    {
        var generator = GetGenerator(frequency);
        if (generator != null)
        {
            generator.Stop();
        }
    }
