    bool isValidAppointment = true;
    // Go through all accepted appointments
    foreach (Appointment item in acceptedAppointments)
    {
        // Check if the difference between the appointments is less than 60 minutes
        if (item.Appointment_DateTime.Substract(myDate).Duration.TotalMinutes < 60)
        {
            // If so, set bool to indicate invalid appointment and stop validation
            isValidApopintment = false;
            break;
        }
    }
    if (isValidAppointment)
    {
        // Handle valid appointment
    }
    else
    {
        // Handle invalid appointment
    }
