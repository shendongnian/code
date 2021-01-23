    for(int x = this.Controls.Count - 1; x >= 0; x--))
    {
        Control ctr = this.Controls[x]; 
        if (ctr Is Label && ctr.Tag != null && ctr.Tag.ToString() == "dispose")
        {
            this.Controls.Remove(ctr);
            ctr.Dispose();
        }
        if(ctr Is TrackBar && ctr.Tag != null && ctr.Tag.ToString() == "dispose")
        {
            this.Controls.Remove(ctr);
            ctr.Dispose();
        }
    }
