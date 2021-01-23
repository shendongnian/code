    public abstract class State {
        public bool AppliesTo( Foo foo );
    }
   
    public class StateOne : State {
        public override bool AppliesTo( Foo foo ){
            return foo.Item.All(x => x is Bar1);
        }
    }
    //etc.
