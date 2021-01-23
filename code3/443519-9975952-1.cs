    public class Rotator
    {
        public Roll, Pitch, Yaw;
        // Declarations here (...)
    }
    
    private Rotator rotation = new Rotator();
    public Rotator Rotation
    {
        get { return rotation; }
        set
        {
            // Since value is of the same type as our variable (Rotator)
            // then we can access it's components.
            if (value.Yaw > 180) // Limit yaw to a maximum of 180°
                value.Yaw = 180;
            else if (value.Yaw < -180) // Limit yaw to a minimum of -180°
                value.Yaw = -180;
            rotation = value;
        }
    }
