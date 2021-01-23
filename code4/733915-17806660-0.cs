    public class MyClass
      {
        public string MyProperty;
        public string[] MyArray;        
      }
    string json = JsonConvert.SerializeObject(new MyClass() { MyProperty = "Test",  MyArray = new string[] { "Test1", "Test2" } });
        //{"MyProperty":"Test","MyArray":["Test1","Test2"]}"
