    public async void Run(IBackgroundTaskInstance taskInstance) {
        var defferal=taskInstance.GetDeferral();
        await InstantSchedule();
        defferal.Complete();
    }
    public static async Task InstantSchedule() {
            [...]
    }
