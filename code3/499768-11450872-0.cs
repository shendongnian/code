    private IEnumerable<EventSchedule> GetTodaySchedules(string tab)
    {
         var today = DateTime.Now.Date;
		 var result = Database.EventSchedules.Where(s => 
		 s.RecurrenceStart.Value.Date <= today && 
		 s.RecurrenceStart.Value.TimeOfDay > today.TimeOfDay &&
		 s.RecurrenceEnd.Value.Date >= today &&
		 s.BaseEvent.EndShow > DateTime.Now &&
		 s.BaseEvent.IsApproved.Value && !s.IsRemoved.Value).ToList();
         if(string.IsNullOrWhiteSpace(tab))
         {
             s.BaseEvent.EventsCategories.Any(c => c.EventCategory.Name == tab)).ToList();
         }
    }
