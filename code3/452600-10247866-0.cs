    [ScriptIgnore]
    private List<Foo> myFoo;
    
    public List<Foo> MyFoo
    {
       get
       {
          if (this.myFoo != null && this.myFoo.Count > 0)
          {
             return this.myFoo;
          }
          else
          {
             return null;
          }
       }
    }
