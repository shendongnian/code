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
        List<Train> trains;
        public NationalRailways()
        {
            this.trains = new List<Train>();
        }
        public Train BuyTrain(ITrainProducer factory)
        {
            // you can call MakeTrain() because the ITrainProducer guarantees that it can make trains
            trains.Add(factory.MakeTrain());
        }
    }
    
