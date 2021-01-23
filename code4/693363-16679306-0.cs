    class MyBaseClass
    {
        public int SomeVariable{get;set;}
    }
    class MyDerivedClass : MyBaseClass
    {
    .............
    }
    List<MyBaseClass> l=new List<MyBaseClass>();
    l[0].SomeVariable=111;
