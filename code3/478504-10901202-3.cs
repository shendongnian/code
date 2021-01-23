    foreach (Control control in panel.Controls)
    {
        if (control.Name == "YourLabelName")
        {
            panel.Controls.Remove(control);
            break;
        }
    }
