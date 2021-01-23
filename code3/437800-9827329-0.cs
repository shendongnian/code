    public enum Unit
    {
      Pound,
      Kilo,
      Kilometer,
      Mile
    }
    
    public class UnitMapping
    {
    
      public UnitMapping(Unit source, Unit target, double factor)
      {
        SourceUnit = source;
        TargetUnit = target;
        Factor = factor;
      }
    
      public Unit SourceUnit { get; private set; }
    
      public Unit TargetUnit { get; private set; }
    
      public double Factor { get; private set; }
    
    }
    
    public class UnitCalculator
    {
      public const string FILE_INPUT = @"Kilo,Pound,0.45359237
                                         Kilometer,Mile,1.609344";
    
    
      private List<UnitMapping> mappings;
    
      public UnitCalculator()
      {
        this.mappings = new List<UnitMapping>();
    
        // parse the mappings
        foreach (var line in FILE_INPUT.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries))
        {
          var fields = line.Split(',');
    
          var source = (Unit)Enum.Parse(typeof(Unit), fields[0]);
          var target = (Unit)Enum.Parse(typeof(Unit), fields[1]);
          double factor = double.Parse(fields[2], CultureInfo.InvariantCulture);
    
          this.mappings.Add(new UnitMapping(source, target, factor));
        }
      }
    
      public double Convert(Unit source, Unit target, double value)
      {
        foreach (var mapping in this.mappings)
        {
          if (mapping.SourceUnit == source && mapping.TargetUnit == target)
          {
            return value * mapping.Factor;
          }
          else if (mapping.SourceUnit == target && mapping.TargetUnit == source)
          {
            return value * (1 / mapping.Factor);
          }
        }
    
        throw new InvalidOperationException("No mapping could be found for this conversion.");
      }
    
    }
