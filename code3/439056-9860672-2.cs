    public class TestClass
    {
        public DateTime BookingEnd;
    }
    //Using Json.Net
    var str1 = JsonConvert.SerializeObject(new TestClass() { BookingEnd = DateTime.Now });
    //Using JavaScriptSerializer 
    JavaScriptSerializer ser = new JavaScriptSerializer();
    var str2 = ser.Serialize(new TestClass() { BookingEnd = DateTime.Now });
    //Using DataContractJsonSerializer 
    MemoryStream m = new MemoryStream();
    DataContractJsonSerializer ser2 = new DataContractJsonSerializer(typeof(TestClass));
    ser2.WriteObject(m, new TestClass() { BookingEnd = DateTime.Now });
    string str3 = Encoding.UTF8.GetString(m.ToArray());
  
