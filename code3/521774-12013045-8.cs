    currentShift.FilingMeasurements
                    .Where(f => TimeSpan.Parse(f.MeasurementTime.MeasurementTime) == ShiftEnd)
                    .GroupBy(f => new { f.Medium, f.MeasurementTime }, s => s.Filing)
                    .Select(t => new { t.Key.Medium, t.Key.MeasurementTime, VolumeInTanks = t.Sum() })
                    .ToList();
