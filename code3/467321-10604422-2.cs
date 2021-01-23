    public delegate void ChangedEventHandler(object sender, EventArgs e);
    
    Class A
    {
       public event ChangedEventHandler Changed;
       int val = 0;
       int Val
       {
          get { return val;}
          set { 
              if ( val != value ) val = value
              {
                  val = value;
                  if (Changed != null) Changed(this, new EventArgs());
              }
              
       }
    }
    
    
    class B
    {
        A obj1, obj2, obj3, obj4;
        int Val {get;set;}
    
        public B()
        {
           obj1 = new A();
           obj1.Changed += new ChangedEventHandler(ElementChanged);
           obj2 = new A(); 
           ...
        }
        
        private void ElementChanged(object sender, EventArgs e) 
          {
             this.Val = (sender as A).Val;
          }
    }
