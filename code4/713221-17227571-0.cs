    public class WaypointNameConverter : DefaultForNullOrWhiteSpaceStringConverter
    {
        public WaypointNameConverter()
        {
            base.Default = Resources.AppResources.Waypoint_NoName;
        }
    }
