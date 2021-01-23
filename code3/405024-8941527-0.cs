    public Employee GetEmployee(int Index)
    {
      var e = list[Index];  // should work, e will be of type Object
      return (Employee) e; // <<<<<The problems
    }
