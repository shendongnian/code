      public class CalculatorComparer : IEqualityComparer<Calculator>
    {
        public bool Equals(Calculator x, Calculator y)
        {
            return (x.ComputationMode.Equals(y.ComputationMode) && x.Mode.Equals(y.Mode));
        }
        public int GetHashCode(Calculator obj)
        {
            return obj.ComputationMode.GetHashCode() ^ obj.Mode.GetHashCode();
        }
    }
    public class Calculator
    {
        public DashboardsComputationMode ComputationMode { get; set; }
        public Modes Mode { get; set; }
        public Calculator(DashboardsComputationMode dashboardsComputationMode, Modes mode)
        {
            ComputationMode = dashboardsComputationMode;
            Mode = mode;
        }
      
        public override bool Equals(object obj)
        {
            Calculator y = obj as Calculator;
            return (this.ComputationMode.Equals(y.ComputationMode) && this.Mode.Equals(y.Mode));
        }
    }
    public enum DashboardsComputationMode
    {
        Weighted = 0,
        Aggregated = 1,
        PR = 2,
        CurrentValue = 3,
        EquivalentHours = 4,
        AggregatedCorrected = 5,
        PRCorrected = 6
    }
    public enum Modes
    {
        InstantaneousMode = 0,
        DailyMode = 1,
        MonthlyMode = 2,
        YearlyMode = 5,
        Undefined = 4,
    }
