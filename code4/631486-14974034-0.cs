    List<Control> controlsToDispose = new List<Control>();
    foreach (Control c in Scratch.tScratch.panel2.Controls)
    {
           if (c.Location.Y == arrDynamY[1])
           {
               controlsToDispose.Add(c);
               c.Dispose();
           }
    }
    while(controlsToDispose.Count>0)
    {
          Control ctrl = controlsToDispose[0];
          controlsToDispose.RemoveAt(0);
          ctrl.Dispose();
    }
