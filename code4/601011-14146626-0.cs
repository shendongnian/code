    public class MyClass
    {
        public int MyInt { get; set; }
        public string MyString { get; set; }
    }
    List<MyClass> myList = new List<MyClass>();
    myList.Add(new MyClass { MyInt = 1, MyString = "string" });
