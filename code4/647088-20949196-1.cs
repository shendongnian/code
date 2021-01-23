    var initialDensity = new MultivariateNormalDistribution(2);
    
    // Creates a sequence classifier containing 2 hidden Markov Models with 2 states 
    // and an underlying multivariate mixture of Normal distributions as density. 
    var classifier = new HiddenMarkovClassifier<MultivariateNormalDistribution>(
        classes: 2, topology: new Forward(2), initial: initialDensity);
    
    // Configure the learning algorithms to train the sequence classifier 
    var teacher = new HiddenMarkovClassifierLearning<MultivariateNormalDistribution>(
        classifier,
    
        // Train each model until the log-likelihood changes less than 0.0001
        modelIndex => new BaumWelchLearning<MultivariateNormalDistribution>(
            classifier.Models[modelIndex])
        {
            Tolerance = 0.0001,
            Iterations = 0,
    
            FittingOptions = new NormalOptions()
            {
                Diagonal = true,      // only diagonal covariance matrices
                Regularization = 1e-5 // avoid non-positive definite errors
            }
        }
    );
    
    // Train the sequence classifier using the algorithm 
    double logLikelihood = teacher.Run(sequences, labels);
    
