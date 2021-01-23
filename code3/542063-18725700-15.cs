    public MyDerivedClass GetPopulatedDerivedClass()
    {
       var newDerivedClass = new MyDerivedClass();
      
       FillBaseClass(newDerivedClass);
       newDerivedClass.UniqueProperty1 = "Some One";
       newDerivedClass.UniqueProperty2 = "Some Thing";
       newDerivedClass.UniqueProperty3 = "Some Thing Else";
       return newDerivedClass;
    }
