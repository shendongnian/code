    TimeSpan total = new TimeSpan();
    TextBox footxt = (TextBox)GridView2.FooterRow.FindControl("footxt1");
    foreach (GridViewRow row in GridView2.Rows)
    {
        TextBox txts = (TextBox)row.FindControl("text11");
        total += TimeSpan.Parse(txts.Text);
    }
    footxt.Text = Convert.ToString(hours);
