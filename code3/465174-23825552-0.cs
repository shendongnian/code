    Patient pt =  dc.Patients.Join(dc.PatientDetails, pm => pm.PatientId, pd => pd.PatientId,
                             (pm, pd) => new
                             {
                                 pmm = pm,
                                 pdd = pd
                             })
                             .Where(i => i.pmm.PatientCode == patientCode && i.pmm.IsActive || i.pdd.Mobile.Contains(patientCode))
                             .Select(s => new Patient
                             {
                                 PatientId = s.pmm.PatientId,
                                 PatientCode = s.pmm.PatientCode,
                                 DateOfBirth = s.pmm.DateOfBirth,
                                 IsActive = s.pmm.IsActive,
                                 UpdatedOn = s.pmm.UpdatedOn,
                                 UpdatedBy = s.pmm.UpdatedBy,
                                 CreatedOn = s.pmm.CreatedOn,
                                 CreatedBy = s.pmm.CreatedBy
                             })
