    public abstract class TestingObservableNamedTriggerBase : ObservableNamedTriggerBase {
      protected override sealed void OnPropertyChanged(string propertyName) {
        base.OnPropertyChanged(propertyName);
      }
    }
