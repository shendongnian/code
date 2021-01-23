    List<BaseItems> _lstBase ; // populated original list
    Public DeleteApp(List<IAppointment> appointmentsToCheck)
    {
      // Find the base objects to remove
      var toRemove = _lstBase.Where(bi => bi.Appointments.Any
                    (app => appointmentsToCheck.Contains(app)));
      // Remove em! 
      foreach (var bi in toRemove)
        _lstBase.Remove(bi);
    }
