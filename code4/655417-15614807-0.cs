    public class Control : CompositeControl {
  
      private bool mProperty;
      private HiddenField hiddenField;
      public virtual bool Property {
        get {
          return mProperty;
        }
        set {
          mProperty = value;
          if (contentPanel != null) contentPanel.Visible = value;
          if (hiddenField != null && hiddenField.Value != value.ToString().ToLower()) hiddenField.Value = value.ToString().ToLower();
        }
      }
      protected override void CreateChildControls() {
        Controls.Clear();
        CreateControlHierarchy();
        ClearChildViewState();
      }
      protected virtual void CreateControlHierarchy() {
        CreateHiddenField();
        CreateContent();
      }
      protected virtual void CreateHiddenField() {
        hiddenField = new HiddenField();
        hiddenField.ID = "hiddenField";
        hiddenField.Value = Property.ToString().ToLower();
        hiddenField.ValueChanged += hiddenField_ValueChanged;
        Controls.Add(hiddenField);
      }  
      protected virtual void CreateContent() {
        contentPanel = new Panel();
        contentPanel.ID = "content";
        contentPanel.Vsiible = Property;
        Controls.Add(contentPanel);
      }
      void hiddenField_ValueChanged(object sender, EventArgs e) {
        Property = Convert.ToBoolean(hiddenField.Value);
      }
      protected override void OnInit(EventArgs e) {
        EnsureChildControls();
        base.OnInit(e);
      }
    }
