    public class Observer
    {
     private MonitoredClass _monitoredClass;
     private DataClass _dataClass;
     public void Setup(MonitoredClass monitoredClass, DataClass dataClass)
     {
        _monitoredClass = monitoredClass;
        _dataClass = dataClass;
        _monitoredClass.PropertyChanged+=MonitoredClassPropertyChanged;
     }
     private void MonitoredClassPropertyChanged(..)
     {
        _dataClass.LastProperty1Value = _monitoredClass.Property1;
     }
    }
