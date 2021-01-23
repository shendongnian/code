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
