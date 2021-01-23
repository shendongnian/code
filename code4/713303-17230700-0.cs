    public static MyType GetType6()
    {
       MyType type = new MyType();
       type.name = "x";
       type.age = 1;
       return type;
    }
    class MyType
    {
       public string name {get;set;}
       public int age {get;set;}
      
       public MyType()
       {
       }
    }
