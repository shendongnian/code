    var focusedCtrl = this.ActiveControl;
    var siblings = Controls.Where(c => c.Location.Y == focusedCtrl.Location.Y).ToList();
    foreach (Control c in siblings)
    {
       // all thise controls are on the same row, providede that the allign
    }
