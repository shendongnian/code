    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        if (Tab.Count > 0)
        {
            foreach (FloorsInformation floorsInformation in Tab)
            {
                floorsInformation.Dispose();
            }
        }
        base.Dispose(disposing);
    }
