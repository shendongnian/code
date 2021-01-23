    class MyClass
    {
       public int Id {get;set;}
       public string Name {get;set;}
       public decimal Val {get;set;}
    }
    int i = 0;
    var myClassImp = new MyClass();
    foreach (var val in new [object]{"10", "My name", "100.21"} // Could be read from some data source, such as an excel spreadsheet
    {
       var prop = typeof(MyClass).GetProperties().ElementAt(i++);
       // !!!!!! THROWS EXCEPTION  !!!!!!!
       prop.SetValue(myClassImp, System.Convert.ChangeType(val, prop.PropertyType), null);
    }
