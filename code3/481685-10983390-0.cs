    public class MakeGraphState()
    {
        // These don't have to be objects, but I don't know
        // what types your toplot, ite, and mm_0 paramters are
        public object toplot { get; set; }
        public object ite { get; set; }
        public object mm_0 { get; set; }
    }
    
    public static void makegraph(object state)
    {
        // Convert state to a MakeGraphState so we can get
        // all of the input paramters
        MakeGraphState myState = (MakeGraphState)object;
        makegraph(myState.toplot, myState.ite, myState.mm_0);
    }
