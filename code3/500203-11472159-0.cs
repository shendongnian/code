    public struct PeriodVars
    {
        public int Past { get; set; }
        public int Present { get; set; }
        public int Future { get; set; }
    }
    public struct VarStruct
    {
        public PeriodVars City;
        public PeriodVars County;
        public PeriodVars State;
    }
