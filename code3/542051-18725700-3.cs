    public MyDerivedClass GetPopulatedDerivedClass()
    {
       var newDerivedClass = (MyDerivedClass)GetPopulatedBaseClass();
      
       newDerivedClass.UniqueProperty1 = "Some One";
       newDerivedClass.UniqueProperty1 = "Some Thing";
       newDerivedClass.UniqueProperty1 = "Some Thing Else";
       return newDerivedClass;
    }
