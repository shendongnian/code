    using System;
    using System.Globalization;
    
    namespace ParlayRMS.Models.System
    {
    
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
