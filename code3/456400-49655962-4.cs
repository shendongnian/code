    public class ViewModel : ViewModelBase
    {
      public ViewModel()
      {
        AvailableItems = typeof(TestEnum).GetEnumValues().Cast<TestEnum>().Select((e) => new SelectableItem<TestEnum>(e)).ToList();
      }
      public IEnumerable<SelectableItem<TestEnum>> AvailableItems { get; private set; }
    }
