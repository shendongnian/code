    // Outside left border
    if (panel.Left < 0) { panel.Left = 0; }
    // Outside top border
    if (panel.Top < 0) { panel.Top = 0; } 
    // Outside right border
    if ((panel.Left + panel.Width) > form.Width)
    {
        panel.Left = form.Width - panel.Width;
    } 
    // Outside bottom border
    if ((panel.Top + panel.Height) > form.Height)
    {
        panel.Top = (form.Height - panel.Height);
    } 
