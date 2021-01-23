    string StartTime = ((TextBox)TestDV.FindControl("txtBST")).Text.ToString();
    DateTime dt = new DateTime();
    try { dt = Convert.ToDateTime(StartTime); } 
    catch(FormatException) { dt = Convert.ToDateTime("12:00 AM"); }
    StartTime = dt.ToString("HH:mm");
