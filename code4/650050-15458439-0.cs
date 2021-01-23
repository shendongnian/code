    class MyClass
    {
        int ID;
        string Name;
        decimal Salary;
    }
    ...
  
    bool IsValid(MyClass myInstance)
    {
       int nameInt;
       return ((myInstance.Salary % 1) == 0) && // check salary
              int.TryParse(myInstance.Name, out nameInt); // check name
    }
    ...
     // verify that all items in list are valid
    List<MyClass> myList = ...
    bool listValid = myList.All(IsValid)
