    List<Student> list1 = new List<Student>();
    // ... add instances with the same name and age
    
    // option 1: use HashSet<T>
    var set = new HashSet<Student>(list1, new MyOrderingClass());
    Assert.Equal(1, set.Count);
    // option 2: use Distinct
    var distinct = list1.Distinct(new MyOrderingClass());
    Assert.Equal(1, distinct.Count());
    // option 3: when you don't have a proper set (e.g. .Net 2.0)
    Dictionary<Student, Object> d = new Dictionary<Student, Object>(new MyOrderingClass());
    list1.ForEach(delegate(Student e) { d[e] = null; });
    Assert.Equal(1, d.Count);
