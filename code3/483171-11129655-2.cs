    [DesignTimeVisible(false)]
    public class PanelItem : Component  {
      [DefaultValue(typeof(string), "")]
      public string PanelText { get; set; }
      private string name = string.Empty;
      [Browsable(false)]
      [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
      public string Name {
        get {
          if (base.Site != null) {
            name = base.Site.Name;
          }
          return name;
        }
        set {
          name = value;
        }
      }
    }
