    public class MyUserControl : UserControl, IDataErrorInfo
    {
       public static readonly DependencyProperty ItemNameProperty =
           DependencyProperty.Register(
               "ItemName",
               typeof(string),
               typeof(MyUserControl),
               new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault)
       );
       public string ItemName
       {
          get { return (string)GetValue(ItemNameProperty); }
          set { SetValue(ItemNameProperty, value); }
       }
       public string Error
       {
          get { throw new NotImplementedException(); }
       }
       public string this[string columnName]
       {
          get
          {
             // use a specific validation or ask for UserControl Validation Error 
             return Validation.GetHasError(this) ? "UserControl has Error" : null;
          }
       }
    }
