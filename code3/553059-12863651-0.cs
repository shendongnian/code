    Panel aspPanel = new Panel();
    Button aspbutton = new Button();
    aspbutton.Text = "Download PDF";
    aspbutton.Click += initDownload;
    aspPanel.Controls.Add(aspbutton);
    aspPanel.Controls.Add(new LiteralControl("some more text!"));
