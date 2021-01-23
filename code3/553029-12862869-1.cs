    int totHours, totMinutes
    TextBox footTxt = (TextBox)GridView2.FooterRow.FindControl("footxt1");
    
    foreach (GridViewRow row in GridView2.Rows)
    {
        TextBox txts = (TextBox)row.FindControl("text11");
        TimeSpan ts = TimeSpan.Parse(txts.Text);
        
        totHours += ts.Hours;
        totMinutes += ts.Minutes;
     
    }
    footTxt.Text = totHours.ToString();
