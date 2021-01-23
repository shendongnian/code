    Button btn = new Button();
    btn.Text = "Example";
    btn.Name = "Button";
    btn.Size = new Size(60, 10);
    Panel panel = new Panel();
    panel.Size = new Size(FlowLayoutPanel1.Width, 10);
    //size of the flowlayoutpanel + height of button
    btn.Dock = DockStyle.Right;
    FlowLayoutPanel1.Controls.Add(panel);
    panel.controls.@add(btn);
