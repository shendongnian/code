    public MyDerivedClass GetPopulatedDerivedClass()
    {
       var newDerivedClass = new MyDerivedClass();
      
       FillBaseClass(newDerivedClass);
       newDerivedClass.UniqueProperty1 = "Some One";
       newDerivedClass.UniqueProperty1 = "Some Thing";
       newDerivedClass.UniqueProperty1 = "Some Thing Else";
       return newDerivedClass;
    }
