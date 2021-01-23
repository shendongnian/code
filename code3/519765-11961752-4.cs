    public class ConcreteDoStuff : IDoStuffInterface
    {
        // Explicit interface member implementation:
        // This method is not directly visible as a member of the class.
        void IDoStuffInterface.DoStuff(IMarkerInterface obj)
        {
            // Do something with 'obj', or throw an exception when
            // it has the wrong type. Delegate the call to the
            // other DoStuff method if you wish.
        }
        
        // Normal method, technically not related to the interface method:
        public void DoStuff(ConcreteObject c)
        {
            // Do your thing.
        }
    }
