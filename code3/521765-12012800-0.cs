    internal class VolumeData
    {
       public string Medium;
       public DateTime MeasurementTime;
       public decimal VolumeInTanks;
    }
    
    public static List<VolumeData> GetVolumeData(this Shift shift)
    {
       return shift.FilingMeasurements
                   .Where(f => TimeSpan.Parse(f.MeasurementTime.MeasurementTime) == ShiftEnd)
                   .GroupBy(f => new { f.Medium, f.MeasurementTime })
                   .Select(t => new VolumeData{ 
                                    Medium = t.Key.Medium, 
                                    MeasurementTime = t.Key.MeasurementTime, 
                                    VolumeInTanks = t.Sum(s => s.Filing) })
                   .ToList();
    }
    
    ...
    
    var groupedFillingsCurrentShift = currentShift.GetVolumeData();
    
    
    if (previousShift != null)
        var groupedFillingsPreviousShift = previousShift.GetVolumeData();
