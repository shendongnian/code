    public class XSettingsExtension : Binding
    {
       [ConstructorArgument("Prefix")]
       public string Prefix { get; set; }
    
       private bool _BindingSet;
       [ConstructorArgument("BindNow")]
       public bool BindNow
       {
          get { return this._BindingSet; }
          set { this._BindingSet = value; SetBinding(); }
       }
