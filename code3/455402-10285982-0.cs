    //Give it a better name; this isn't designed to be a general purpose class
    public class MyCompositeDisposable : IDisposable 
    {
        public MyCompositeDisposable (string uri, int id, int innerid)
        {
            A = SomeFactory.GetA(uri);
            B = A.GetB(id);
            C = B.GetC(innerId);
        }
    
        //You can make A & B private if appropriate; 
        //not sure if all three or just C should be exposed publicly.
        //Class names are made up; you'll need to fix.  
        //They should also probably be given more meaningful names.
        public ClassA A{get;private set;}
        public ClassB B{get;private set;}
        public ClassC C{get;private set;}
    
        public void Dispose()
        {
            A.Dispose();
            B.Dispose();
            C.Dispose();
        }
    }
