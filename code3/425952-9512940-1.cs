    public interface IHasGear { Gear gear { get; set; } }
    public abstract class BHasGear : IHasGear { public virtual Gear gear { get; set; } }
    public class MeatGrinder : BHasGear 
    { 
        //no need to implement gear, the abstract class already implemented it
        private Gear oldToothyOne { get; set; } }
    }
