    internal void MinButt_Click(object sender, EventArgs e)
    {
        Scratch.tScratch.panel2.Controls.RemoveByKey("Record" + arrDynamY[0].ToString());
        var controlsToDispose = new List<Control>();
        foreach (Control c in Scratch.tScratch.panel2.Controls)
        {
            if (c.Location.Y == arrDynamY[1])
            {
                controlsToDispose.Add(c);
            }
        }
        foreach (Control c in controlsToDispose )
        {
            c.Dispose();
        }              
    }
