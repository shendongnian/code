    public class ExtendedAppointment
    {
        Appointment _appointment;
        public ExtendedAppointment(Appointment appointment)
        {
            _appointment = appointment;
        }
        public Appointment Appointment { get { return _appointment; } }
        public object SomeExtendedProperty
        {
            get 
            { 
                return _appointment.ExtendedProperties[0].Value;
            }
            set
            {
                _appointment.ExtendedProperties[0].Value = value;
            }
        }
    }
