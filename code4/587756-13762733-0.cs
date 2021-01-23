    var hours = Enumerable.Range(00, 24).Select(i => i.ToString("D2"));
    var minutes  = Enumerable.Range(00, 60).Select(i => i.ToString("D2"));
    dlOh1OpenHours.DataSource = hours;
    ddlOh1OpenHours.DataBind();
    ddlOh1OpenMinutes.DataSource = minutes;
    ddlOh1OpenMinutes.DataBind();
