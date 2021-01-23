    public class GeneticAlgorithmParameters {
      
      public double CrossoverRate { get; private set; }
      ...
      public GenericAlgorithmParameters(double crossoverRate, ... others) {
        CrossoverRate = crossoverRate;
        ...
      }
    }
