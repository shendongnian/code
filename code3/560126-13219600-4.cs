    protected override void Dispose(bool disposing)
    {
        Tab.Clear();
        Tab.RemoveRange(0, Tab.Count);
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }
