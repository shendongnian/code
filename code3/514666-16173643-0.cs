    private static readonly PropertyDefinitionBase AppointementIdPropertyDefinition = new ExtendedPropertyDefinition(DefaultExtendedPropertySet.PublicStrings, "AppointmentID", MapiPropertyType.String);
    public static PropertySet PropertySet = new PropertySet(BasePropertySet.FirstClassProperties, AppointementIdPropertyDefinition);
    
    
    //Setting the property for the appointment 
     public static void SetGuidForAppointement(Appointment appointment)
    {
        try
        {
            appointment.SetExtendedProperty((ExtendedPropertyDefinition)AppointementIdPropertyDefinition, Guid.NewGuid().ToString());
            appointment.Update(ConflictResolutionMode.AlwaysOverwrite, SendInvitationsOrCancellationsMode.SendToNone);
        }
        catch (Exception ex)
        {
            // logging the exception
        }
    }
    
    //Getting the property for the appointment
     public static string GetGuidForAppointement(Appointment appointment)
    {
        var result = "";
        try
        {
            appointment.Load(PropertySet);
            foreach (var extendedProperty in appointment.ExtendedProperties)
            {
                if (extendedProperty.PropertyDefinition.Name == "AppointmentID")
                {
                    result = extendedProperty.Value.ToString();
                }
            }
        }
        catch (Exception ex)
        {
         // logging the exception
        }
        return result;
    } 
