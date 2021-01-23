    private List<TimeSheetItem> GetData()
    {
        return new List<TimeSheetItem>()
        {
             new TimeSheetItem() { Name = "IN1" }
            ,new TimeSheetItem() { Name = "IN2" }
            ,new TimeSheetItem() { Name = "IN3" }
            ,new TimeSheetItem() { Name = "IN4" }
            ,new TimeSheetItem() { Name = "Personal" }
            ,new TimeSheetItem() { Name = "Doctor" }
            ,new TimeSheetItem() { Name = "Other" }
            ,new TimeSheetItem() { Name = "Sick" }
            ,new TimeSheetItem() { Name = "Vacation", Thursday2 = 8 } // Put in your 8 hours
            ,new TimeSheetItem() { Name = "Holiday" }
            ,new TimeSheetItem() { Name = "Meeting" }
        };
    }
