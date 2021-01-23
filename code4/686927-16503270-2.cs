    public class CustomType {
      public int IntVal { get; set; }
      public string StrVal { get; set; }
    }
    ...
    ViewBag.SomeObject = new CustomType { IntVal = 5, StrVal = "Hello" }
