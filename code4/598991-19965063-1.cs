    namespace Extensions
    {
       public class LongListSelectorEx : LongListSelector
       {
          protected override System.Windows.Size MeasureOverride(System.Windows.Size availableSize)
          {
             if (this.ItemsSource == null)
                return new System.Windows.Size(this.Width, 0);
             if (this.ItemsSource.Count <= 0)
                return new System.Windows.Size(this.Width, 0);
    
             return base.MeasureOverride(availableSize);
          }
       }
    }
