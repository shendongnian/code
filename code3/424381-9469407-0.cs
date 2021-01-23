    public class ThingTask
    {
      public virtual string Name { get; set; }
      public virtual ThingType Type { get; set; }
      public virtual ThingOperation Operation { get; set; }
      public virtual void DoThing() { /*Do something associated with ThingTask*/ }
    }
    public class AdvancedThingTask : ThingTask
    {
      public bool EnableFrobber { get; set; }
      public override void DoThing() { /*Do something associated with AdvancedThingTask*/ }
    }
