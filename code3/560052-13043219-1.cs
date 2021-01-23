    List<Student> list1 = new List<Student>();
    // ... add instances with the same name and age
    
    // option 1: use HashSet<T>
    var set = new HashSet<Student>(list1, new MyOrderingClass());
    Assert.Equal(1, set.Count);
    // option 2: use Distinct
    var distinct = list1.Distinct(new MyOrderingClass());
    Assert.Equal(1, distinct.Count());
    
