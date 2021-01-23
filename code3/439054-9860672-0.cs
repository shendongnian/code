    {"BookingEnd":"\/Date(1332683194843)\/"}
---
    public class TestClass
    {
        public DateTime BookingEnd;
    }
    //Using Json.Net
    var str1 = JsonConvert.SerializeObject(new TestClass() { BookingEnd = DateTime.Now });
    //Using JavaScriptSerializer 
    JavaScriptSerializer ser = new JavaScriptSerializer();
    var str2 = ser.Serialize(new TestClass() { BookingEnd = DateTime.Now });
  
