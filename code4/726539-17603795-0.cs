    public bool eligibleAppointment()
    {
            wsBase.Client cli = new wsBase.Client();
            wsBase.Employee emp = new wsBase.Employee();
            wsBase.Patient pat = new wsBase.Patient();
    
            DateTime DOB = pat.DOB;
            DateTime appt = cli.AppointmentDate;
    }
