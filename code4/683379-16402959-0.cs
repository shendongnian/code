    internal class ParamWithUnit
    {
      public string Unit { get; set; }
      public double Value { get; set; }
    }
    internal class Params
    {
      private ParamWithUnit diae = new ParamWithUnit();
      public ParamWithUnit Diae 
      {
        get { return this.diae; }
      }
    }
