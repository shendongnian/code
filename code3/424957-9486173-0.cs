    public class Thing
    {
         public Thing(Thing thing)
         {
             this.UsefulID = thing.UsefulId;
             ....
         }
    }
    
    public class ThingEditView : Thing
    {
         public ThingEditView(ThingEditView thing) : base(thing) {
              this.A = thing.A;
              this.B = thing.B;
         }
    }
    
    var foo = new ThingEditView(thisThing);
    foo.C = "";
