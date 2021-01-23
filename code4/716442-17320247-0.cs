    pulbic Entry 
    {
        public ObjA propsA3 { get; set; }
    }
    
    public ObjA
    {
       public int Prop1 {get, set};
       public int Prop2 {get, set};
    
       public int this[ObjB b]
       {
          get { return getVal(b); }
          set { /* do something*/ }
       }
    
       private int getVal3(ObjB b) {return calSomethin(b);}
       private int setVal3(ref ObjB b, int val) { /*do something to ObjB*/}
    }
