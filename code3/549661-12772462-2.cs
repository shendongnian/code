    private void renderSubtitles(object sender, EventArgs e)
    {
        var ts = TimeSpan.FromSeconds(player.Ctlcontrols.currentPosition);
        var entry = entries.FirstOrDefault(o => o.Start <= ts && o.End >= ts);
        if (entry != null)
        {
            subtitle.Visible = true;
            subtitle.Text = entry.Text;
            
            var w = splitContainer.Panel1.Width;
            subtitle.Location = new Point(w / 2 - subtitle.Width / 2, subtitle.Location.Y);
        }
        else
        {
            subtitle.Visible = false;
        }
    }
