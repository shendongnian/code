        public enum NameOfMonth
        {
            january = 1,
            febuary,
            march,
            april,
            may,
            june,
            july,
            august,
            september,
            october,
            november,
            december
        }
    
        class CalendarEvent
        {
            public NameOfMonth month;
            public DateTime date { get; set; }
            public string eventdescription { get; set; }
    
            public CalendarEvent()
            {
                
            }
        }
