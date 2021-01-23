    [NotMapped]
    public Measure Measure 
    { 
        get { return MeasureRegistration.Measures
                    .FirstOrDefault(m => m.MeasureName == this.MeasureName; }
        set { this.MeasureName == value.MeasureName;}
    }
