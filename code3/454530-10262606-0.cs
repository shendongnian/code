    public ObservableCollection<Alarm> FutureAlarms { get; private set;} // initialize in constructor
 
    private void UpdateFutureAlarms() {
        fAlarms.Clear();
        fAlarms.AddRange(
            alarms.Where(
                a => a.DateTime > DateTime.Now 
                    || (a.EndRecurrency != null && a.EndRecurrency > DateTime.Now)
            )
        )
    }
    //... somewhere else in the code... 
    public void Foo () {
        // change the list
        alarms.Add(someAlarm);
        UpdateFutureAlarms();
    }
        
