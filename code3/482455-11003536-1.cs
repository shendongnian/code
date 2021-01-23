    protected override void OnInit(EventArgs eventArgs) {
      base.OnInit(eventArgs);
      CreateDynamicControl(); 
    }
    private void CreateDynamicControl() {
      Place.Controls.Clear();
      Place.Controls.Add(ControlFactory.Create(TypeDropDown.SelectedValue);
    }
    private void OnTypeChanged(object sender, EventArgs eventArgs) {
      CreateDynamicControl();
    }
