    public class A:B
    {
        int _c = 0;
    
        public int p1 //this is child property
        {
            get { return _c; }
            set { _c = value; isChiledchanged= true; } //here change, notify class B that p1 is changed
        }
    
    }
    
    public class B
    {
       public bool isChildchanged = false;
    
        
    }
