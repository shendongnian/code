    class ExcludeItemDialogViewModel : DialogViewModelBase
    {
      public ExcludeItemDialogViewModel(string title, string excludeItem)
      {
        AddValidator(() => ExcludedItem, new NotNullOrEmptyValidationRule());
    
        // Code removed for clarity...
      }
    
      // Code removed for clarity...
    }
