    public List<Appointment> GetAppointments()      
    {
        return dataEntities.Appointments
                           .Where(a => a.PATIENTID == PatientId)
                           .Select(a => new OtherNamespace.Appointment 
                                        {
                                            Id = a.Id,
                                            Name = a.Name,
                                            // etc.
                                        })
                           .ToList();
    }
