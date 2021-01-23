    List<Control> listControls = new List<Control>();
    foreach (Control control in flowLayoutPanel.Controls)
    {
        listControls.Add(control);
    }
    foreach (Control control in listControls)
    {
        control.Dispose();
    }
