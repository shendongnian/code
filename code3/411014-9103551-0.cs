    public static MeasuringInstrument Instrument(this IDevice device)
    {
      if (device is InstrumentedDevice)
      {
        return (device as InstrumentedDevice).Instrument;
      }
      
      return null;
    }
    var groups = devices.GroupBy(d => d.Instrument());
    foreach (var gr in groups) 
