    class Blah{
 
        string mol = "The meaning of life is";
        int a = 42;    
        
        public override string ToString()
        {
             return String.Format("{0} {1}", mol, a);
        }
    }
    System.Diagnostics.Debug.WriteLine(new Blah().ToString());
