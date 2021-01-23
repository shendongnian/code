    public Neuron(int neuronIndex, int neuronInputs)
    {
        for (int i = 0; i < neuronInputs; i++)
        {
            this.index = neuronIndex;
            this.weights.Add(_random.NextDouble());
        }
    }
