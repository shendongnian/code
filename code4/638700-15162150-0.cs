    private static readonly Random rnd = new Random();
    public Neuron(int neuronIndex, int neuronInputs)
    {
        private static readonly rnd = new Random();     
        for (int i = 0; i < neuronInputs; i++)
        {
            this.index = neuronIndex;
            this.weights.Add(rnd.NextDouble());
        }
    }
