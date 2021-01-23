    protected void DetailsView1_ItemCommand(Object sender, DetailsViewCommandEventArgs e) {
      if (e.CommandName == "btnSelectAll") {
        var controls = new Stack<Control>();
        controls.Push(DetailsView1);
        while (controls.Count > 0) {
          var control = controls.Pop();
          var checkbox = control as CheckBox;
          if (checkbox != null) {
            checkbox.Checked = true;
          }
          foreach (Control childControl in control.Controls) {
            controls.Push(childControl);
          }
        }
      }
    }
