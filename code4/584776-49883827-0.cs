     ReadOnlyCollection<TimeZoneInfo> objTimeZones = null;
     objTimeZones = TimeZoneInfo.GetSystemTimeZones();
     if (objTimeZones.Count > 0)
     {
         //List<TimeZoneMaster> listTimeZones = new List<TimeZoneMaster>();
        
         foreach (var timezone in objTimeZones.ToList())
         {
              TimeZoneMaster objTimeZoneMaster = new TimeZoneMaster();
             objTimeZoneMaster.TimeZoneName = timezone.DisplayName;
             var localName = timezone.DisplayName;
             objTimeZoneMaster.TimeZoneOffsetInMinutes = Convert.ToInt32(timezone.BaseUtcOffset.TotalMinutes);                      
             objVTMMedicalDBDataContext.TimeZoneMasters.InsertOnSubmit(objTimeZoneMaster);
             objVTMMedicalDBDataContext.SubmitChanges();
         }
     }
}   
