    class Program
    {
      struct Data
      {
        public Data (int l, int u, int v)
        {
          lower = l;
          upper = u;
          value = v;
        }
        public int lower;
        public int upper;
        public int value;
      }
      static void Main (string [] args)
      {
        Data []
          // at the moment, this is coded into the source
          // it can be read from a file at run time instead
          data = { new Data (0, 180, 14), new Data (180, 540, 28), new Data (540, 1068, 42) };
        int
          // again, the default case is hard coded, it too can be loaded from a file
          x = 56,
          workedDays = 100;
        foreach (Data item in data)
        {
          if (workedDays > item.lower && workedDays <= item.upper)
          {
            x = item.value;
            break;
          }
        }
      }
    }
