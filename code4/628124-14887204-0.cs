    var publicTask = PublicCalendars.Update();
    var privateTask = PrivateCalendars.Update();
    await publicTask;
    await privateTask;
    BusyState.ClearBusy();
