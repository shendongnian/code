    public class ApptData
    {
        private static ApptData _defaultInstance;
        public static ApptData Default
        {
            if (_defaultInstance == null)
            {
                 _defaultInstance = new ApptData();
            }
            return _defaultInstance;
        }
        public DateTime CurrentAppointment { get; set; }
    }
