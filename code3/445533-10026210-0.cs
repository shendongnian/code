    public class ProgressBarViewModel : INotifiedPropertyChanged
    {
        //add INotifyPropertyChanged implementation
        //add Properties you want to bind to the ProgressBar
        ...
        //For example
        public double Value { //getter, setter methods. Raise PropertyChanged in setter if value changed}
       ...
    }
