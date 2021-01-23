    public override IEnumerable<IKPIDetails> MakeReportDataStructure()
    {
        List<AirTemp_KPIDetails> d = new List<AirTemp_KPIDetails>();
        return  d;  // <-- works, because T in IEnumerable is covariant
    }
