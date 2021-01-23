    var onlineAppointments = new List<Appointment>();
    var localAppointments = new List<Appointment>();
    var appointment01 = new Appointment( 1, new DateTime( 2012, 12, 24, 17, 30, 00 ),
                                            new DateTime( 2012, 12, 24, 17, 45, 00 ) );
    var appointment02 = new Appointment( 2, new DateTime( 2012, 12, 24, 17, 30, 00 ),
                                            new DateTime( 2012, 12, 24, 17, 45, 00 ) );
    
    onlineAppointments.Add( appointment01 );
    localAppointments.Add( appointment02 );
    
    var comparer = new AppointmentEqualityComparer<Appointment>();
    var diffOnlineOffline = onlineAppointments.Except( localAppointments, comparer ).ToList();
