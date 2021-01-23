    List ChangedControls = new List(Of, String);
    private void ChangedValue(object sender, System.EventArgs e) {
        WebControl cntrl = (WebControl) sender;
        ChangedControls.Add(cntrl.ID);
    }
