    protected override void Dispose(bool disposing)
    {
        ... a whole lot of resource reclaiming/funky code ...
         ControlCollection controls = (ControlCollection) 
                this.Properties.GetObject(PropControlsCollection);
         if (controls != null)
         {
             for (int i = 0; i < controls.Count; i++)
             {
                  Control control = controls[i];
                  control.parent = null;
                  control.Dispose();
             }
             this.Properties.SetObject(PropControlsCollection, null);
          }
          base.Dispose(disposing);
