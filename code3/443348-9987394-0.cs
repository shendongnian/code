    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Microsoft.LightSwitch;
    using Microsoft.LightSwitch.Security.Server;
    namespace LightSwitchApplication
    {
    public partial class ApplicationDataService
    {
        
        partial void StatusCallBackRequired_PreprocessQuery(ref IQueryable<PatientsTelephoneFollowupDetail> query)
        {
            var required = query.Where(PatientNeedCallback);
        }
        public static bool PatientNeedCallback(PatientsTelephoneFollowupDetail p)
        {
            var last = p.PatientsMasterItem.PatientsTelephoneFollowupDetail.LastOrDefault(c => c.Status == "7" || c.Status == "1");
            return last != null && last.Status == "7";
        }
    }    
               
              
    }
