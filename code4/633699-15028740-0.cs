    Double days = 0;
    DateTime cs= DateTime.Now;
    bool daysOk = Double.TryParse(textbox1.Text, out days);
    if (daysOk) 
    {
       cs = cs.AddDays(days);
    }
    else
    {
       textbox1.Text = "invalid days";
    }
