    int hours, minutes, hoursCpt, minutesCpt;
    hoursCpt = 0;
    minutesCpt = 0;
    TextBox footxt = (TextBox)GridView2.FooterRow.FindControl("footxt1");
    foreach (GridViewRow row in GridView2.Rows)
    {
        TextBox txts = (TextBox)row.FindControl("text11");
        TimeSpan ts = TimeSpan.Parse(txts.Text);
        hours = ts.Hours;
        minutes = ts.Minutes;
        hoursCpt += hours;
        minutesCpt  += minutes;
     }
     footxt.Text = Convert.ToString(hoursCpt + ((minutesCpt  - minutesCpt  % 60) / 60));
