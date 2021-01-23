    public partial class App : Application
    {
        public App()
        {
            HarvestApp.GoogleAPIManager GAPImanager = new HarvestApp.GoogleAPIManager();
        
            List<Event>todayCalendar = GAPImanager.GetCalendarEventsForDate(DateTime.Today);
        
            HarvestApp.HarvestManager HAPIManager = new HarvestApp.HarvestManager();
        
            Console.WriteLine("Entries found for Today :" + todayCalendar.Count);
        
            foreach(Event todayEvent in todayCalendar)
            {
                var addEvent = new HarvestApp.Harvest_TimeSheetEntry(todayEvent);
                EntryList.Add(addEvent);
                HAPIManager.postHarvestEntry(addEvent);
            }
        }
     }
