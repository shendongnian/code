    Task<List<Analyser.ALARM_GROUP>> analysertask = Task.Factory.StartNew<List<Analyser.ALARM_GROUP>>(
        ()=> {
            // Keep existing code
            return Analyser1.startAnalysis(PlantModelReader1, AlarmlogReader1, RuleBaseLoader1, AlarmList1); 
             });
    // Make a continuation here...
    analysertask.ContinueWith( t =>
        {
            Cursor = Cursors.Wait;
            List<Analyser.ALARM_GROUP> alarmGroupList = t.Result;
            showAlarmLog(alarmGroupList);
            Cursor = Cursors.Arrow;
        }, TaskScheduler.FromCurrentSynchronizationContext());
