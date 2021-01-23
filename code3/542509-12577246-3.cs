    public ObservableCollection<CustomClass> AllEvents = new public ObservableCollection<CustomClass>();
    //AllEvents.Add(customclassref1);
    //AllEvents.Add(customclassref2);
    //AllEvents.Add(customclassref3);
    SerializeHelper.SaveData<ObservableCollection<CustomClass>>("AllEvents", AllEvents);
