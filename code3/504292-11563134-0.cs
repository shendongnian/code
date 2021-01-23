    public class MyClassSpecialComparer : IEqualityComparer<myClass>
    {
        public bool Equals (myClass x, myClass y)
        { 
            return x.A == y.A && x.B == y.B 
        }
        public int GetHashCode(myClass x)
        {
           return x.GetHashCode();
        }
        
    }
     //Special case for when you only want it to compare this one time
        var myClassSpecialComparer = new MyClassSpecialComparer();
        Dictionary<myClass, List<string>> dict = new Dictionary<myClass, List<string>>();
        //(Snip)
        if (dict.Keys.Contains(second, myClassSpecialComparer ))
        {
            //
            //should come here and update List<string> for first (and only in this example) key 
            //
        }
     //If you want it to always compare
        Dictionary<myClass, List<string>> dict = new Dictionary<myClass, List<string>>(new MyClassSpecialComparer());
