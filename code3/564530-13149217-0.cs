    class Appliance
    {
      private Kitchen _parent;
      public Appliance(Kitchen parent) { _parent = parent; }
      void Activate()
      {
        _parent.myStuff.WriteCommand(ApplianceAddress, 1);
      }
      void Deactivate()
      {
        _parent.myStuff.WriteCommand(ApplianceAddress, 0);
      }
    }
