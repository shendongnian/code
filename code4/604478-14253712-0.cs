    namespace ParlayRMS.Models.System
    {
        using global::System;
        using global::System.Globalization;
    
        public class MaintenanceInfo
        {
            public MaintenanceInfo()
            {
                IsDownTime = false;
                TimeFrom = DateTime.Now.ToString(CultureInfo.InvariantCulture);
                TimeTo = DateTime.Now.ToString(CultureInfo.InvariantCulture);
            }
            public bool IsDownTime { get; set; }
            public string TimeFrom { get; set; }
            public string TimeTo { get; set; }
        }
    }
