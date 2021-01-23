    foreach (Label label in Controls.OfType<Label>())
    {
        if (label.Tag != null && label.Tag.ToString() == "dispose")
        {
            this.Controls.Remove(label);
            label.Dispose();
        }
    }
    foreach (TrackBar trackBar in Controls.OfType<TrackBar>())
    {
        if (trackBar.Tag != null && trackBar.Tag.ToString() == "dispose")
        {
            this.Controls.Remove(trackBar);
            trackBar.Dispose();
        }
    }
