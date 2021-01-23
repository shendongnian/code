    public double GetXValue()
    {
      if (AlgoType == Algos.Futures)
      {
        return 5.0;
      }
      else if (AlgoType == Algos.Stock)
      {
        return Algo2.y;
      }
      //else
      throw new Exception("unknown algo type");
    }
