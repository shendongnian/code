    // Holds an Activity, and all the DefaultEventTypes corresponding to it.
    class ActivityWithEvents {
        public Activity Activity { get; set; }
        public IEnumerable<DefaultEventType> Events { get; set; }
    }
    // Holds a Mission, and all the Activities corresponding to it.
    class MissionWithActivities {
        public Mission Mission { get; set; }
        public IEnumerable<ActivityWithEvents> Activities { get; set; }
    }
