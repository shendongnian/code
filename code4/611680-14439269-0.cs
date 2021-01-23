    private Reminders reminder = new Reminders();
    private dynamic defaultReminder;
    public YourClass()
    {
        defaultReminder = reminder.TimeSpanText[TimeSpan.FromMinutes(15)];
    }
