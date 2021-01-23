    var patientDetails = dc.Patients.Join(dc.PatientDetails, pm => pm.PatientId, pd => pd.PatientId,
                     (pm, pd) => new
                     {
                         pmm = pm,
                         pdd = pd
                     })
                     .Where(i => i.pmm.PatientCode == patientCode && i.pmm.IsActive || i.pdd.Mobile.Contains(patientCode))
                     .Select(s => new 
                     {
                         PatientId = s.pmm.PatientId,
                         PatientCode = s.pmm.PatientCode,
                         DateOfBirth = s.pmm.DateOfBirth,
                         IsActive = s.pmm.IsActive,                     
                         PatientMobile = s.pdd.Mobile,
                         s.pdd.Email,
                         s.pdd.District,
                         s.pdd.Age,
                         s.pdd.SittingId
                         
                     })
