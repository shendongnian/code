    /// <summary>Custom ListView.</summary>
    public sealed partial class DetailsListView : ListView
    {
       ...
       [DefaultValue(false)]
       public new bool MultiSelect {
          get { return base.MultiSelect; }
          set { base.MultiSelect = value; }
       }
