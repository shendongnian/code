    [ConfigurationProperty("unit", DefaultValue = MeasurementUnits.Pixel)]
    [TypeConverter(typeof(CaseInsensitiveEnumConfigConverter<MeasurementUnits>))]
    public MeasurementUnits Unit { get { return (MeasurementUnits)this["unit"]; } }
    public enum MeasurementUnits
    {
            Pixel,
            Inches,
            Points,
            MM,
    }
