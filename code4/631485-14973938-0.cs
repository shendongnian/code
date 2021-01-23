    var controlsToRemove = from Control c in Scratch.tScratch.panel2.Controls
                           where c.Location.Y == arrDynamY[1]
                           select c;
    foreach (var c in controlsToRemove.ToArray())
    {
        Scratch.tScratch.panel2.Controls.Remove(c);
        c.Dispose();
    }
