        enum Level
        {
            Warning,
            Error
        }
        class ITemInListView
        {
            public string message { get; set; }
            public Level level { get; set; }
        }
