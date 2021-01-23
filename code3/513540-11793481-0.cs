    public Train
    {
        private price;
        public Train(float price) { this.price = price; }
    }
    public IMyInterface
    {
       Train MakeTrain();
    }
    
    public ExpensiveTrainFactory : ITrainProducer
    {
        // make a luxury, expensive train
        public Train MakeTrain() { return new Train(4000.0); }
    }
    
    public CheapTrainFactory : ITrainProducer
    {
        // make a cheap train
        public Train MakeTrain() { return new Train(500.0); }
    }
    
    public NationalRailways
    {
        public Train BuyTrain(ITrainProducer factory)
        {
            // you can call MakeTrain() because the ITrainProducer guarantees that it can make trains
            Train train = factory.MakeTrain();
        }
    }
    
