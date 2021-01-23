    BinaryProblemConfiguration config = new BinaryProblemConfiguration();
    config.XRange = new Range<int>(0, 100);
    config.YRange = new Range<int>(-50, 50);
    
    IProblemFactory problemFactory = new BinaryProblemFactory(config);
