    public class cookieTest
    {
        testC test;
        public cookieTest()
        {
            test = new testC();
        }
        public testC GetTestC
        {
            get
            {
                var cookie = HttpContext.Current.Request.Cookies["test"];
                return Deserialize<testC>(cookie.Value);
            }
            set
            {
                var cookie = new HttpCookie("test");
                cookie.Expires = DateTime.Now.AddHours(8);
                cookie["first"] = Serialize(value);
                System.Web.HttpContext.Current.Response.Cookies.Add(cookie);
            }
        }
    
        private static string Serialize<T>(T instance)
        {
            using (var stream = new MemoryStream())
            {
                var serializer = new BinaryFormatter();
                serializer.Serialize(stream, instance);
                return Convert.ToBase64String(stream.ToArray());
            }
        }
    
        private static T Deserialize<T>(string value)
        {
            using (var stream = new MemoryStream(Convert.FromBase64String(value)))
            {
                var serializer = new BinaryFormatter();
                return (T)serializer.Deserialize(stream);
            }
        }
    }
