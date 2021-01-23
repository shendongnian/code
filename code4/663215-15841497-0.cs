    var calibration = new Calibration
    {
        CalibrationType = SelectedTest.TestTypeId
        ,Expiration = expirationDate
        ,LastSaved = DateTime.Now
        ,StatusTypeId = 1
        ,TechnicianId = SelectedTechnician.Id
        ,Phases = BuildCalibrationPhases()
    };
    db.Calibrations.Add(calibration);
    db.SaveChanges();
    
    
    int value = Calibration.PrimaryKeyProperty;
