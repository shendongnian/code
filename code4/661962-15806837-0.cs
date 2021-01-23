    var d = DateTime.Now;
    if (d.Minute < 15) { d.AddMinutes(15 - d.Minute); }
    else if (d.Minute < 30) { d = d.AddMinutes(30 - d.Minute); }
    else if (d.Minute < 45) { d = d.AddMinutes(45 - d.Minute); }
    else if (d.Minute < 60) { d = d.AddMinutes(60 - d.Minute); }
    d = d.AddMinutes(45);
