    var appointments = _service.FindAppointments(WellKnownFolderName.Calendar, calendarView);
    ExtendedPropertyDefinition def = new ExtendedPropertyDefinition(DefaultExtendedPropertySet.PublicStrings, "RateTheMeetingId", MapiPropertyType.Integer);
    PropertySet propset = new PropertySet(PropertySet.IdOnly);
    propset.Add(def);
    foreach (var appointment in appointments)
    {
        //appointment should already be binded, now load it
        appointment.Load(propset);
        object value = null;
        if (item.TryGetProperty(def, out value))
        {
            //Do something
        }
        else
        {
            //Add Property
        }
    }
